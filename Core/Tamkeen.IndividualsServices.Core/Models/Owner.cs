using Tamkeen.IndividualsServices.Core.Data;
using System.Collections.Generic;

namespace Tamkeen.IndividualsServices.Core.Models
{
    public partial class Owner : BaseEntity<long>
    {

        public string Name { get; set; }

        public string IdNo { get; set; }

        public System.DateTime? IdExpiryDate { get; set; }

        public virtual ICollection<UnifiedNumber> UnifiedNumbers { get; set; } = new List<UnifiedNumber>();
    }
}
