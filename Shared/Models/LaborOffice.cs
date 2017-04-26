using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public partial class LaborOffice
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UnifiedNumber> UnifiedNumbers { get; set; } = new List<UnifiedNumber>();
        public virtual ICollection<Establishment> Establishments { get; set; } = new List<Establishment>();

    }
}
