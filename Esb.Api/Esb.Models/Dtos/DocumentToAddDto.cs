﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esb.Models.Dtos
{
    public class DocumentToAddDto
    {
        public required string Description { get; set; }
        public required string CreatedBy { get; set; }
    }
}
