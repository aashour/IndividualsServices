using Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public partial class LaborOffice : BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<UnifiedNumber> UnifiedNumbers { get; set; } = new List<UnifiedNumber>();
        public virtual ICollection<Establishment> Establishments { get; set; } = new List<Establishment>();
        public virtual ICollection<Laborer> Laborers { get; set; } = new List<Laborer>();
        public virtual ICollection<User> Users { get; set; } = new List<User>();

    }
}
