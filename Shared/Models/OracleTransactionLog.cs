using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public partial class OracleTransactionLog
    {
        public long Id { get; set; }

        public long OnlineRequestsId { get; set; }

        public int ServiceId { get; set; }

        public long? UserId { get; set; }

        public long? LaborerId { get; set; }

        public int LabOff { get; set; }

        public int SerYY { get; set; }

        public int SeqNo { get; set; }

        public long EstablishmentId { get; set; }

        public string RepresentativeIdNo { get; set; }

        public int? TransactionStatus { get; set; }

        public string OracleResult { get; set; }

        public string Error { get; set; }

        public bool? ManPower { get; set; }

        public System.DateTime? TimeStamp { get; set; }

        public virtual Service Service { get; set; }

        public virtual Establishment Establishment { get; set; }

        public virtual User User { get; set; }
        public virtual Laborer Laborer { get; set; }

    }
}
