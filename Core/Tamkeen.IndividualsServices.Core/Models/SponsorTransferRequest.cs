using System;
using Tamkeen.IndividualsServices.Core.Data;

namespace Tamkeen.IndividualsServices.Core.Models
{
    public partial class SponsorTransferRequest //: BaseEntity<long>
    {
        public int NewEstablishmentLaborOfficeId { get; set; }
        public long NewEstablishmentSequenceNumber { get; set; }
        public string NewEstablishmentName { get; set; }
        public int LaborOfficeId { get; set; }
        public long SeqeunceNumber { get; set; }
        public int Year { get; set; }
        public DateTime RequestDate { get; set; }
        public SponsorTransferRequestStatusList Status { get; set; }
        public long IdNumber { get; set; }
        public int OldEstablishmentLaborOfficeId { get; set; }
        public long OldEstablishmentSequenceNumber { get; set; }
        public string OldEstablishmentName { get; set; }
    }
}
