using System.ComponentModel.DataAnnotations;

namespace Esb.Api.Entities
{
    public class House
    {
        [Key]
        public int ObjectId { get; set; }
        public required string Code { get; set; }
        public required string Street { get; set; }
        public int Number { get; set; }
        public string? Addition { get; set; }
        public required string ZipCode { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
        public string? ExternalCode { get; set; }
        public required string Customer { get; set; }
        public int? YearBuild { get; set; }
        public bool Daeb { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime? CreationDate { get; set; }
        public required string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set;}
        public bool Active { get; set; }

        public ICollection<Complex>? Complexes { get; set; }
        public ICollection<ServiceContract>? ServiceContracts { get; set; }
        public ICollection<Document>? Documents { get; set; }
        public ICollection<Image>? Images { get; set; }
        public ICollection<Serviceorder>? Serviceorders { get; set; }

        public ICollection<HouseComplex>? houseComplexes { get; set; }
        public ICollection<HouseDocument>? houseDocuments { get; set; }
        public ICollection<HouseImage>? HouseImages { get; set; }
        public ICollection<HouseServiceContract>? HouseServiceContracts { get; set; }
        public ICollection<HouseServiceorder>? HouseServiceorders { get; set; }
    }
}
