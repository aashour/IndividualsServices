using Shared.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
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
        public virtual ICollection<ServiceLog> ServiceLogs { get; set; } = new List<ServiceLog>();
        public virtual ICollection<OracleTransactionLog> SponsoTransferRequests { get; set; } = new List<OracleTransactionLog>();

    }
}
