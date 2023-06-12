using Esb.Api.Entities;
using Esb.Api.Extensions;
using Esb.Api.Repositories.Contracts;
using Esb.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Esb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageDto>>> GetImages()
        {
            try
            {
                var images = await imageRepository.GetImages();

                if (images == null)
                {
                    return NotFound();
                }
                else
                {
                    var imageDtos = images.ConvertToDto();
                    return Ok(imageDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ImageDto>> GetImage(int id)
        {
            try
            {
                var image = await imageRepository.GetImage(id);

                if (image == null)
                {
                    return BadRequest();
                }
                else
                {
                    var imageDto = image.ConvertToDto();

                    var response = new ObjectResult(imageDto)
                    {
                        StatusCode = (int)HttpStatusCode.OK,
                    };

                    return Ok(imageDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("imagefile/{id:int}")]
        public async Task<ActionResult> GetImageFile(int id)
        {
            try
            {
                var image = await imageRepository.GetImage(id);

                if (image == null)
                {
                    return BadRequest();
                }
                else
                {
                    var filePath = image.URL;
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
        public async Task<ActionResult<ImageDto>> PostImage([FromForm] ImageToAddDto imageToAddDto, IFormFile file)
        {
            try
            {
                string basePath = "D:\\API\\Photos\\";
                string extension;
                string fileName;
                string filePath;

                if (file.Length > 0)
                {
                    string[] permittedExtensions = { ".png", ".jpg", ".svg" };

                    extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                    fileName = Path.GetRandomFileName().ToLowerInvariant(); //Random for extra security
                    filePath = basePath+fileName+extension;

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

                    var newImage = await imageRepository.AddImage(imageToAddDto, filePath);
                    if (newImage == null)
                    {
                        return NoContent();
                    }

                    var newImageDto = newImage.ConvertToDto();

                    return CreatedAtAction(nameof(GetImage), new { id = newImageDto.ImageId }, newImageDto);
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
        //public async Task<ActionResult<Image>> DeleteImage(int id)
        //{
        //    try
        //    {
        //        var image = await imageRepository.DeleteImage(id);
        //        if (image == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(image);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //                           "Error retrieving data from the database");
        //    }
        //}

    }
}
