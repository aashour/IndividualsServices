using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tamkeen.IndividualsServices.WebAPIs.Models
{
    public class RunawayRequestDto
    {
        public DateTime RequestDate { get; set; }
        public DateTime RunawayDate { get; set; }
        public string EstablishmentName { get; set; }
        public string RequesterName { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }
        public DateTime? CancellationDate { get; set; }
        public string CancellationReason { get; set; }
        public int CancellationReasonId { get; set; }
        public IEnumerable<RunawayComplaintDto> RunawayComplaintRequests { get; set; } = new List<RunawayComplaintDto>();
    }
}
