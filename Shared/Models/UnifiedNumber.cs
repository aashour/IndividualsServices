using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public partial class UnifiedNumber
    {
        public long Id { get; set; }
        public int LaborOfficeId { get; set; }
        public long SequenceNumber { get; set; }
        public long SevenHundredNumber { get; set; }

        public int? OwnerId { get; set; }

        public virtual LaborOffice LaborOffice { get; set; }
        public virtual Owner Owner { get; set; }

        public virtual ICollection<Establishment> Establishments { get; set; } = new List<Establishment>();

    }
}
