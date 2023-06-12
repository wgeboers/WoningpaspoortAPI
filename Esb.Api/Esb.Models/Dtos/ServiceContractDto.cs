﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esb.Models.Dtos
{
    public class ServiceContractDto
    {
        public int ServiceContractId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
