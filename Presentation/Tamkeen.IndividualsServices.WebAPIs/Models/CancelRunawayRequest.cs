using System;

namespace Tamkeen.IndividualsServices.WebAPIs.Models
{
    public class CancelRunawayRequest
    {
        public string Number { get; set; }
        public DateTime RuquestDate { get; set; }
        public string EstablishmentName { get; set; }
        public string ComplaintReason { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }
    }
}
