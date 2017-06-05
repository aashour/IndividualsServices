using Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class RunawayComplaint : BaseEntity<int>
    {
        public long EstablishmentId { get; set; }
        public DateTime ComplaintDate { get; set; }
        public int CreatedByUserId { get; set; }
        public long? RunawayLaborId { get; set; }
        public int StatusId { get; set; }
        public DateTime? NoteEndDate { get; set; }
        public int ComplaintSequence { get; set; }
        public string RejectReason { get; set; }
        public DateTime? DecisionDate { get; set; }
        public int DecidedByUserId { get; set; }
        public string ClientIPAddress { get; set; }
        public int RunawayRequestId { get; set; }
        public virtual ServiceLog RunawayRequest { get; set; }
        public string Reason { get; set; }
        public virtual Establishment Establishment { get; set; }
    }

}
