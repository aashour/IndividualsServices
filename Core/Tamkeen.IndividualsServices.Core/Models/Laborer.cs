using Tamkeen.IndividualsServices.Core.Data;
using System;
using System.Collections.Generic;

namespace Tamkeen.IndividualsServices.Core.Models
{
    public partial class Laborer : BaseEntity<long>
    {
        public int LaborOfficeId { get; set; }
        public int SaudiFlagId { get; set; }
        public long SequenceNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
        public string IdNo { get; set; }
        public short NationalityId { get; set; }
        public int JobId { get; set; }
        public long EstablishmentId { get; set; }
        public int? StatusId { get; set; }
        public string BorderNo { get; set; }
        public int? TypeId { get; set; }
        public virtual LaborerStatus Status { get; set; }
        public virtual SaudiFlag SaudiFlag { get; set; }
        public virtual Job Job { get; set; }
        public virtual Nationality Nationality { get; set; }
        public virtual Establishment Establishment { get; set; }
        public virtual LaborOffice LaborOffice { get; set; }
        public virtual LaborerType Type { get; set; }
        //public virtual ICollection<TransferRequest> TransferRequests { get; set; } = new List<TransferRequest>();

        public virtual ICollection<OracleTransactionLog> SponsorTransferRequests { get; set; } = new List<OracleTransactionLog>();
        public int YearOfBirth { get; set; }
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public DateTime? LastWPExpirationDate { get; set; }
        public string PassportNo { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public DateTime? ServiceEndDate { get; set; }
        public DateTime? LaborerStatusModificationDate { get; set; }
        //public ICollection<RunawayRequest> RunawayRequests { get; set; }
        public ICollection<ServiceLog> ServiceLogs { get; set; }
    }
}
