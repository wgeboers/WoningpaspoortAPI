using Microsoft.AspNetCore.Http;

namespace Esb.Models.Dtos
{
    public class ImageToAddDto
    {
        public required string Description { get; set; }
        public required string CreatedBy { get; set; }
        public required bool Thumbnail { get; set; }
    }
}
