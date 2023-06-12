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
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepository documentRepository;

        public DocumentController(IDocumentRepository documentRepository)
        {
            this.documentRepository = documentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentDto>>> GetDocuments()
        {
            try
            {
                var documents = await documentRepository.GetDocuments();

                if (documents == null)
                {
                    return NotFound();
                }
                else
                {
                    var documentDtos = documents.ConvertToDto();
                    return Ok(documentDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DocumentDto>> GetDocument(int id)
        {
            try
            {
                var document = await documentRepository.GetDocument(id);

                if (document == null)
                {
                    return BadRequest();
                }
                else
                {
                    var documentDto = document.ConvertToDto();
                    return Ok(documentDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("documentfile/{id:int}")]
        public async Task<ActionResult> GetDocumentFile(int id)
        {
            try
            {
                var document = await documentRepository.GetDocument(id);

                if(document == null)
                {
                    return BadRequest();
                }
                else
                {
                    var filePath = document.URL;
                    var stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
                    return File(stream, "text/plain", Path.GetFileName(filePath));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<DocumentDto>> PostDocument([FromForm] DocumentToAddDto documentToAddDto, IFormFile file)
        {
            try
            {
                string basePath = "D:\\API\\Documents\\";
                string extension;
                string fileName;
                string filePath;

                if (file.Length > 0)
                {
                    string[] permittedExtensions = { ".docx", ".pdf", ".xlsx" };

                    extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                    fileName = Path.GetRandomFileName().ToLowerInvariant(); //Random for extra security
                    filePath = basePath + fileName + extension;

                    if (string.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
                    {
                        return StatusCode(StatusCodes.Status405MethodNotAllowed,
                            "Bestandstype " + extension + " is niet toegestaan");
                    }

                    if (file.Length > 5242880) //max of 5mb
                    {
                        return StatusCode(StatusCodes.Status405MethodNotAllowed,
                            "Bestand is groter dan de toegestane limiet van 5 mb");
                    }

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var newDocument = await documentRepository.AddDocument(documentToAddDto, filePath);
                    if (newDocument == null)
                    {
                        return NoContent();
                    }

                    var newDocumentDto = newDocument.ConvertToDto();

                    return CreatedAtAction(nameof(GetDocument), new { id = newDocumentDto.DocumentId }, newDocumentDto);
                }
                else
                {
                    return StatusCode(StatusCodes.Status405MethodNotAllowed,
                            "Er is geen bestand toegevoegd");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult<Document>> DeleteDocument(int id)
        //{
        //    try
        //    {
        //        var document = await documentRepository.DeleteDocument(id);
        //        if (document == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(document);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //                           "Error retrieving data from the database");
        //    }
        //}
    }
}
