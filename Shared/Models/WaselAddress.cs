﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class WaselAddress
    {
        public int? Status { get; set; }
        public string ZipCode { get; set; }
        public string Primary { get; set; }
        public string Secondary { get; set; }
        public string UnitNo { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Street { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
