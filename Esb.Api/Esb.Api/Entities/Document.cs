using System.ComponentModel.DataAnnotations;

namespace Esb.Api.Entities
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        public required string URL { get; set; }
        public string? ExternalURL { get; set; }
        public required string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

        public ICollection<House>? Houses { get; set; }
        public ICollection<HouseDocument>? houseDocuments { get; set; }
    }
}
