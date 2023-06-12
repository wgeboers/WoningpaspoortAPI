using Esb.Api.Entities;
using Esb.Api.Repositories.Contracts;
using Esb.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseImageController : ControllerBase
    {
        private readonly IHouseImageRepository houseImageRepository;
        private readonly IHouseRepository houseRepository;
        private readonly IImageRepository imageRepository;
        public HouseImageController(IHouseImageRepository houseImageRepository,
                                    IHouseRepository houseRepository,
                                    IImageRepository imageRepository) 
        { 
            this.houseImageRepository = houseImageRepository;
            this.houseRepository = houseRepository;
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        public async Task<ActionResult<HouseImageDto>> PostHouseImage([FromBody] HouseImageToAddDto houseImageToAdd)
        {
            try
            {
                House house = await houseRepository.GetHouse(houseImageToAdd.HouseObjectId);
                Image image = await imageRepository.GetImage(houseImageToAdd.ImageId);

                var newHouseImage = await houseImageRepository.AddHouseImage(image, house);
                if (newHouseImage == null)
                {
                    return NoContent();
                }

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
