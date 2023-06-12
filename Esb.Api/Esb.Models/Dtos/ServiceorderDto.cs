using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esb.Models.Dtos
{
    public class ServiceorderDto
    {
        public int ServiceorderId { get; set; }
        public required string ServiceorderNo { get; set; }
        public string? Description { get; set; }
        public string? Customer { get; set; }
        public string? OrderManager { get; set; }
        public string? OrderSoort { get; set; }
        public string? Status { get; set; }
        public string? CustomerReference { get; set; }
        public string? OrderType { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
