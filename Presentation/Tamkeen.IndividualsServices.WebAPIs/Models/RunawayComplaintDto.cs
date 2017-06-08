using System;

namespace Tamkeen.IndividualsServices.WebAPIs.Models
{
    public class RunawayComplaintDto
    {
        public int Id { get; set; }
        public string EstablishmentName { get; set; }
        public DateTime ComplaintDate { get; set; }
        public string Reason { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public string RejectReason { get; set; }
        public DateTime? DecisionDate { get; set; }
    }
}
