using System;
namespace Tamkeen.IndividualsServices.WebAPIs.Models
{
    public class SponsorTransferRequestDto
    {
        public SponsorTransferRequestNumberDto Number { get; set; }
        public DateTime ReqeustDate { get; set; }
        public SponsorTransferEstablishmentDto OldEstablishment { get; set; }
        public SponsorTransferEstablishmentDto NewEstablishment { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }


    }
    public struct SponsorTransferRequestNumberDto
    {
        public int LaborOfficeId { get; set; }
        public long SequenceNumber { get; set; }
        public int Year { get; set; }
    }

    public struct SponsorTransferEstablishmentDto
    {
        public int LaborOfficeId { get; set; }
        public long SequenceNumber { get; set; }
        public string Name { get; set; }
    }
}