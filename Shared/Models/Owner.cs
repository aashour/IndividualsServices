using Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public partial class Owner : BaseEntity<long>
    {

        public string Name { get; set; }

        public string IdNo { get; set; }

        public System.DateTime? IdExpiryDate { get; set; }

        public virtual ICollection<UnifiedNumber> UnifiedNumbers { get; set; } = new List<UnifiedNumber>();
    }
}
