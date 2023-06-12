using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esb.Models.Dtos
{
    public class HouseDocumentDto
    {
        public HouseDto House { get; set; }
        public DocumentDto Document { get; set; }
    }
}
