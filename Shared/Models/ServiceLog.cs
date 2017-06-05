using Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public partial class ServiceLog : BaseEntity<int>
    {
        public int ServiceId { get; set; }
        public long EstablishmentId { get; set; }
        public long LaborerId { get; set; }
        public long UserId { get; set; }
        public string RequesterIdNo { get; set; }
        public virtual Establishment Establishment { get; set; }
        public virtual Laborer Laborer { get; set; }
        public virtual User Requester { get; set; }
        public virtual Service Service { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<RunawayComplaint> RunawayComplaints { get; set; }
    }
}
