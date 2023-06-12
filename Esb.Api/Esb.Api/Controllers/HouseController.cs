using Esb.Api.Entities;
using Esb.Api.Extensions;
using Esb.Api.Repositories.Contracts;
using Esb.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Esb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IHouseRepository houseRepository;
        private readonly IComplexRepository complexRepository;
        private readonly IDocumentRepository documentRepository;
        private readonly IImageRepository imageRepository;
        private readonly IServiceContractRepository serviceContractRepository;
        private readonly IServiceorderRepository serviceorderRepository;
        private readonly IHouseComplexRepository houseComplexRepository;
        private readonly IHouseDocumentRepository houseDocumentRepository;
        private readonly IHouseImageRepository houseImageRepository;
        private readonly IHouseServiceContractRepository houseServiceContractRepository;
        private readonly IHouseServiceorderRepository houseServiceorderRepository;

        public HouseController(IHouseRepository houseRepository, 
                               IComplexRepository complexRepository, 
                               IDocumentRepository documentRepository,
                               IImageRepository imageRepository,
                               IServiceContractRepository serviceContractRepository,
                               IServiceorderRepository serviceorderRepository,
                               IHouseComplexRepository houseComplexRepository,
                               IHouseDocumentRepository houseDocumentRepository,
                               IHouseImageRepository houseImageRepository,
                               IHouseServiceContractRepository houseServiceContractRepository,
                               IHouseServiceorderRepository houseServiceorderRepository)
        {
            this.houseRepository = houseRepository;
            this.complexRepository = complexRepository;
            this.documentRepository = documentRepository;
            this.imageRepository = imageRepository;
            this.serviceContractRepository = serviceContractRepository;
            this.serviceorderRepository = serviceorderRepository;
            this.houseComplexRepository = houseComplexRepository;
            this.houseDocumentRepository = houseDocumentRepository;
            this.houseImageRepository = houseImageRepository;
            this.houseServiceContractRepository = houseServiceContractRepository;
            this.houseServiceorderRepository = houseServiceorderRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HouseDto>>> GetHouses()
        {
            try
            {
                var houses = await houseRepository.GetHouses();

                if (houses == null)
                {
                    return NotFound();
                }
                else
                {
                    var houseDtos = houses.ConvertToDto();
                    return Ok(houseDtos);
                }    
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<HouseDto>> GetHouse(int id)
        {
            try
            {
                var house = await houseRepository.GetHouse(id);

                if (house == null)
                {
                    return BadRequest();
                }
                else
                {
                    var houseDto = house.ConvertToDto();
                    return Ok(houseDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<HouseDto>> GetHouseByCode(string code)
        {
            try
            {
                var house = await houseRepository.GetHouseByCode(code);

                if (house == null)
                {
                    return BadRequest();
                }
                else
                {
                    var houseDto = house.ConvertToDto();
                    return Ok(houseDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<HouseDto>> PostHouse([FromBody] HouseToAddDto houseToAddDto)
        {
            try
            {
                var newHouse = await houseRepository.AddHouse(houseToAddDto);
                if (newHouse == null)
                {
                    return NoContent();
                }

                string? address = null;
                if (newHouse.Addition != null)
                {
                    address = newHouse.Street + " " + newHouse.Number + newHouse.Addition;
                }
                else
                {
                    address = newHouse.Street + " " + newHouse.Number;
                }

                string requestUri = "https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyDaor9nbGkXlR3fNWJX5VvaSxw4nLRI4gk&address=" + address + ", " + newHouse.City + "&sensor=false";

                using (var client = new HttpClient())
                {
                    var request = await client.GetAsync(requestUri);
                    var content = await request.Content.ReadAsStringAsync();
                    var xmlDocument = XDocument.Parse(content);

                    XElement result = xmlDocument.Element("GeocodeResponse").Element("result");
                    XElement locationElement = result.Element("geometry").Element("location");
                    XElement lat = locationElement.Element("lat");
                    XElement lng = locationElement.Element("lng");

                    newHouse.Longitude = (double?)lng;
                    newHouse.Latitude = (double?)lat;
                }

                // Check whether there are complexes in the message. If so, let's go through them one by one.
                if (houseToAddDto.Complexes != null)
                {
                    foreach (ComplexToAddDto complex in houseToAddDto.Complexes)
                    {
                        var complexes = await complexRepository.GetComplexes();
                        var existingComplex = complexes.Where(x => x.Name.Contains(complex.Name));

                        //Check whether any complexes with the same name already exist.
                        //If 1 already exists, we link it instead of creating it again.
                        //This is to avoid duplication
                        if (existingComplex.Any())
                        {
                            await houseComplexRepository.AddHouseComplex(existingComplex.First(), newHouse);
                        }
                        else
                        {
                            var newComplex = await complexRepository.AddComplex(complex);
                            if (newComplex == null)
                            {
                                return NoContent();
                            }

                            await houseComplexRepository.AddHouseComplex(newComplex, newHouse);
                        }
                    }
                }

                //Check whether there are service contracts in the message. If so, let's go through them one by one.
                if (houseToAddDto.ServiceContracts != null)
                {
                    foreach (ServiceContractToAddDto serviceContract in houseToAddDto.ServiceContracts)
                    {
                        var serviceContracts = await serviceContractRepository.GetServiceContracts();
                        var existingServiceContract = serviceContracts.Where(x => x.Name.Contains(serviceContract.Name));

                        //Check if any documents already exist whose url is the same.
                        //If 1 already exists, we link it instead of creating it again.
                        //This is to avoid duplication
                        if (existingServiceContract.Any())
                        {
                            await houseServiceContractRepository.AddHouseServiceContract(existingServiceContract.First(), newHouse);
                        }
                        else
                        {
                            var newServiceContract = await serviceContractRepository.AddServiceContract(serviceContract);
                            if (newServiceContract == null)
                            {
                                return NoContent();
                            }

                            await houseServiceContractRepository.AddHouseServiceContract(newServiceContract, newHouse);
                        }
                    }
                }

                //Check whether there are service orders in the message. If so, let's go through them one by one.
                if (houseToAddDto.ServiceOrders != null)
                {
                    foreach (ServiceorderToAddDto serviceorder in houseToAddDto.ServiceOrders)
                    {
                        var serviceOrders = await serviceorderRepository.GetServiceorders();
                        var existingServiceOrder = serviceOrders.Where(x => x.ServiceorderNo.Contains(serviceorder.ServiceorderNo));

                        //Check whether service orders already exist whose service order number is the same.
                        //If 1 already exists, we link it instead of creating it again.
                        //This is to avoid duplication
                        if (existingServiceOrder.Any())
                        {
                            await houseServiceorderRepository.AddHouseServiceorder(existingServiceOrder.First(), newHouse);
                        }
                        else
                        {
                            var newServiceOrder = await serviceorderRepository.AddServiceorder(serviceorder);
                            if (newServiceOrder == null)
                            {
                                return NoContent();
                            }

                            await houseServiceorderRepository.AddHouseServiceorder(newServiceOrder, newHouse);
                        }
                    }
                }

                //Retrieve the newly created property
                var house = await houseRepository.GetHouse(newHouse.ObjectId);
                var newHouseDto = house.ConvertToDto();

                return CreatedAtAction(nameof(GetHouse), new { id = newHouseDto.ObjectId }, newHouseDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult<House>> DeleteHouse(int id)
        //{
        //    try
        //    {
        //        var house = await houseRepository.DeleteHouse(id);
        //        if (house == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(house);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //                           "Error retrieving data from the database");
        //    }
        //}
    }
}
