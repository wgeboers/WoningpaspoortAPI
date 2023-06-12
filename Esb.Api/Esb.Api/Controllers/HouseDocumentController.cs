using Esb.Api.Entities;
using Esb.Api.Repositories.Contracts;
using Esb.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseDocumentController : ControllerBase
    {
        private readonly IHouseDocumentRepository houseDocumentRepository;
        private readonly IHouseRepository houseRepository;
        private readonly IDocumentRepository documentRepository;

        public HouseDocumentController(IHouseDocumentRepository houseDocumentRepository,
                                        IHouseRepository houseRepository,
                                        IDocumentRepository documentRepository)
        {
            this.houseDocumentRepository = houseDocumentRepository;
            this.houseRepository = houseRepository;
            this.documentRepository = documentRepository;
        }

        [HttpPost]
        public async Task<ActionResult<HouseDocumentDto>> PostHouseDocument([FromBody] HouseDocumentToAddDto houseDocumentToAddDto)
        {
            try
            {
                House house = await houseRepository.GetHouse(houseDocumentToAddDto.HouseObjectId);
                Document document = await documentRepository.GetDocument(houseDocumentToAddDto.DocumentId);

                var newHouseDocument = await houseDocumentRepository.AddHouseDocument(document, house);
                if (newHouseDocument == null)
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
