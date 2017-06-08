using Tamkeen.IndividualsServices.Core.Data;
using System.Collections.Generic;

namespace Tamkeen.IndividualsServices.Core.Models
{
    public partial class UnifiedNumber : BaseEntity<long>
    {
        public int LaborOfficeId { get; set; }
        public long SequenceNumber { get; set; }
        public string SevenHundredNumber { get; set; }

        public long? OwnerId { get; set; }

        public int? TypeId { get; set; }

        public virtual LaborOffice LaborOffice { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual EstablishmentType Type { get; set; }
        public virtual ICollection<Establishment> Establishments { get; set; } = new List<Establishment>();

    }
}
