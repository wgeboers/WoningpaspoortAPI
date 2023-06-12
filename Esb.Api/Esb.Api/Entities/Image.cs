using System.ComponentModel.DataAnnotations;

namespace Esb.Api.Entities
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        public required string URL { get; set; }
        public string? ExternalURL { get; set; }
        public required string Description { get; set; }
        public required bool Thumbnail { get; set; }
        public DateTime CreationDate { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

        public ICollection<House>? Houses { get; set; }
        public ICollection<HouseImage>? HouseImages { get; set; }
    }
}
