using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tamkeen.IndividualsServices.WebAPIs.Models
{
    public class CreateRunawayComplaintDto
    {
        public long IdNumber { get; set; }
        public string Reason { get; set; }
    }
}
