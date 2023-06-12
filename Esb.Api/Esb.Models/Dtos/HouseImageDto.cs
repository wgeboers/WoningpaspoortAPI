using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Esb.Models.Dtos
{
    public class HouseImageDto
    {
        public HouseDto House { get; set; }
        public ImageDto Image { get; set; }
    }
}
