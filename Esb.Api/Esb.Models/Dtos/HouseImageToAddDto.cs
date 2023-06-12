using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esb.Models.Dtos
{
    public class HouseImageToAddDto
    {
        public required int HouseObjectId { get; set; }
        public required int ImageId { get; set; }
    }
}
