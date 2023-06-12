using Esb.Api.Entities;
using Esb.Api.Extensions;
using Esb.Api.Repositories;
using Esb.Api.Repositories.Contracts;
using Esb.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceContractController : ControllerBase
    {
        private readonly IServiceContractRepository serviceContractRepository;

        public ServiceContractController(IServiceContractRepository serviceContractRepository)
        {
            this.serviceContractRepository = serviceContractRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceContractDto>>> GetServiceContracts()
        {
            try
            {
                var serviceContracts = await serviceContractRepository.GetServiceContracts();

                if (serviceContracts == null)
                {
                    return NotFound();
                }
                else
                {
                    var serviceContractDtos = serviceContracts.ConvertToDto();
                    return Ok(serviceContractDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceContractDto>> GetServiceContract(int id)
        {
            try
            {
                var serviceContract = await serviceContractRepository.GetServiceContract(id);

                if (serviceContract == null)
                {
                    return BadRequest();
                }
                else
                {
                    var serviceContractDto = serviceContract.ConvertToDto();
                    return Ok(serviceContractDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ServiceContractDto>> PostServiceContract([FromBody] ServiceContractToAddDto serviceContractToAddDto)
        {
            try
            {
                var newServiceContract = await serviceContractRepository.AddServiceContract(serviceContractToAddDto);
                if (newServiceContract == null)
                {
                    return NoContent();
                }

                var newServiceContractDto = newServiceContract.ConvertToDto();

                return CreatedAtAction(nameof(GetServiceContract), new { id = newServiceContractDto.ServiceContractId }, newServiceContractDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult<ServiceContract>> DeleteServiceContract(int id)
        //{
        //    try
        //    {
        //        var serviceContract = await serviceContractRepository.DeleteServiceContract(id);
        //        if (serviceContract == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(serviceContract);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //                           "Error retrieving data from the database");
        //    }
        //}
    }
}
