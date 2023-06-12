using System.ComponentModel.DataAnnotations;

namespace Esb.Api.Entities
{
    public class HouseComplex
    {
        public House House { get; set; }
        public Complex Complex { get; set; }
    }
}
