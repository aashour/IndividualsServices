using Tamkeen.IndividualsServices.Core.Data;
using System.Collections.Generic;

namespace Tamkeen.IndividualsServices.Core.Models
{
    public partial class EstablishmentStatus : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime? CreatedOn { get; set; }
        public System.DateTime? ModifiedOn { get; set; }
        public virtual ICollection<Establishment> Establishments { get; set; } = new List<Establishment>();
    }
}
