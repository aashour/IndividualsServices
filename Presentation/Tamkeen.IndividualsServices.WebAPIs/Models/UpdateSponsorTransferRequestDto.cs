namespace Tamkeen.IndividualsServices.WebAPIs.Models
{
    public class UpdateSponsorTransferRequestDto
    {
        public int LaborOfficeId { get; set; }
        public int Year { get; set; }
        public long SequenceNumber { get; set; }

        public SponsorTransferRequestAction Action { get; set; }
    }

    public enum SponsorTransferRequestAction
    {
        Approve = 1,
        Reject = 2
    }
}
