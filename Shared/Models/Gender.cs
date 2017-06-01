using Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public partial class Gender : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Laborer> Laborers { get; set; } = new List<Laborer>();
    }
}
