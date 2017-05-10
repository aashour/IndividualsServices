using Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
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
