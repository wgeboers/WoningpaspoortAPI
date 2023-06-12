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
    public class ServiceorderController : ControllerBase
    {
        private readonly IServiceorderRepository serviceorderRepository;

        public ServiceorderController(IServiceorderRepository serviceorderRepository)
        {
            this.serviceorderRepository = serviceorderRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceorderDto>>> GetServiceorders()
        {
            try
            {
                var serviceorders = await serviceorderRepository.GetServiceorders();

                if (serviceorders == null)
                {
                    return NotFound();
                }
                else
                {
                    var serviceorderDtos = serviceorders.ConvertToDto();
                    return Ok(serviceorderDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceorderDto>> GetServiceorder(int id)
        {
            try
            {
                var serviceorder = await serviceorderRepository.GetServiceorder(id);

                if (serviceorder == null)
                {
                    return BadRequest();
                }
                else
                {
                    var serviceorderDto = serviceorder.ConvertToDto();
                    return Ok(serviceorderDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ServiceorderDto>> PostServiceorder([FromBody] ServiceorderToAddDto serviceorderToAddDto)
        {
            try
            {
                var newServiceorder = await serviceorderRepository.AddServiceorder(serviceorderToAddDto);
                if (newServiceorder == null)
                {
                    return NoContent();
                }

                var newServiceorderDto = newServiceorder.ConvertToDto();

                return CreatedAtAction(nameof(GetServiceorder), new { id = newServiceorderDto.ServiceorderId }, newServiceorderDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult<Serviceorder>> DeleteServiceorder(int id)
        //{
        //    try
        //    {
        //        var serviceorder = await serviceorderRepository.DeleteServiceorder(id);
        //        if (serviceorder == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(serviceorder);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //                           "Error retrieving data from the database");
        //    }
        //}
    }
}
