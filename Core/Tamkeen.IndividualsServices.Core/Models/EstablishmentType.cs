using Tamkeen.IndividualsServices.Core.Data;
using System.Collections.Generic;

namespace Tamkeen.IndividualsServices.Core.Models
{
    public class EstablishmentType : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<UnifiedNumber> UnifiedNumbers { get; set; } = new List<UnifiedNumber>();
    }
}
