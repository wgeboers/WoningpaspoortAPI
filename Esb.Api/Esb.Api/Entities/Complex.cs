using System.ComponentModel.DataAnnotations;

namespace Esb.Api.Entities
{
    public class Complex
    {
        [Key]
        public int ComplexId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

        public ICollection<House>? Houses { get; set; }

        public ICollection<HouseComplex>? houseComplexes { get; set; }
    }
}
