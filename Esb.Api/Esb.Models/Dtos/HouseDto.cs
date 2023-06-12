using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Esb.Models.Dtos
{
    public class HouseDto
    {
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

        public ICollection<ComplexDto>? Complexes { get; set; }
        public ICollection<ServiceContractDto>? ServiceContracts { get; set; }
        public ICollection<DocumentDto>? Documents { get; set; }
        public ICollection<ImageDto>? Images { get; set; }
        public ICollection<ServiceorderDto>? Serviceorders { get; set; }
    }
}
