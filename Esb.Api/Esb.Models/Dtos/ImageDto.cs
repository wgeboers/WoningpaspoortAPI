namespace Esb.Models.Dtos
{
    public class ImageDto
    {
        public int ImageId { get; set; }
        public required string URL { get; set; }
        public required string ExternalURL { get; set; }
        public required string Description { get; set; }
        public required bool Thumbnail { get; set; }
    }
}
