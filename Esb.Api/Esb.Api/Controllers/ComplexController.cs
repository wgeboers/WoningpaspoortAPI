using Esb.Api.Entities;
using Esb.Api.Extensions;
using Esb.Api.Repositories.Contracts;
using Esb.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplexController : ControllerBase
    {
        private readonly IComplexRepository complexRepository;

        public ComplexController(IComplexRepository complexRepository)
        {
            this.complexRepository = complexRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComplexDto>>> GetComplexes()
        {
            try
            {
                var complexes = await complexRepository.GetComplexes();

                if (complexes == null)
                {
                    return NotFound();
                }
                else
                {
                    var complexDtos = complexes.ConvertToDto();
                    return Ok(complexDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ComplexDto>> GetComplex(int id)
        {
            try
            {
                var complex = await complexRepository.GetComplex(id);

                if (complex == null)
                {
                    return BadRequest();
                }
                else
                {
                    var complexDto = complex.ConvertToDto();
                    return Ok(complexDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ComplexDto>> PostComplex([FromBody] ComplexToAddDto complexToAddDto)
        {
            try
            {
                var newComplex = await complexRepository.AddComplex(complexToAddDto);
                if (newComplex == null)
                {
                    return NoContent();
                }

                var newComplexDto = newComplex.ConvertToDto();

                return CreatedAtAction(nameof(GetComplex), new { id = newComplexDto.ComplexId }, newComplexDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult<Complex>> DeleteComplex(int id)
        //{
        //    try
        //    {
        //        var complex = await complexRepository.DeleteComplex(id);
        //        if (complex == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(complex);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //                           "Error retrieving data from the database");
        //    }
        //}
    }
}
