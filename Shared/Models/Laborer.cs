using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public partial class Laborer
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public int LaborOfficeId { get; set; }

        public int SaudiFlagId { get; set; }

        [Required]
        public long SequenceNumber { get; set; }

        [StringLength(5)]
        public string FirstName { get; set; }

        [StringLength(5)]
        public string SecondName { get; set; }

        [StringLength(5)]
        public string ThirdName { get; set; }

        [StringLength(5)]
        public string FourthName { get; set; }

        public string IdNo { get; set; }
        public short NationalityId { get; set; }
        public int JobId { get; set; }
        public long EstablishmentId { get; set; }
        public int? StatusId { get; set; }
        public string BorderNo { get; set; }
        public virtual LaborerStatus Status { get; set; }
        public virtual SaudiFlag SaudiFlag { get; set; }
        public virtual Job Job { get; set; }
        public virtual Nationality Nationality { get; set; }
        public virtual Establishment Establishment { get; set; }
        public virtual LaborOffice LaborOffice { get; set; }
        //public virtual ICollection<TransferRequest> TransferRequests { get; set; } = new List<TransferRequest>();

        public virtual ICollection<ServiceLog> ServiceLogs { get; set; } = new List<ServiceLog>();
        public virtual ICollection<OracleTransactionLog> SponsoTransferRequests { get; set; } = new List<OracleTransactionLog>();

    }
}
