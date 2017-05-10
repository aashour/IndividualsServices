using Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public partial class LaborerStatus : BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Laborer> Laborers { get; set; } = new List<Laborer>();
    }
}
