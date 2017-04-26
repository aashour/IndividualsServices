using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public partial class Nationality
    {
        public short Id { get; set; }

        public string Name { get; set; }

        public string NameEN { get; set; }

        public bool? IsIncludedForEWV { get; set; }

        public virtual ICollection<Laborer> Laborers { get; set; } = new List<Laborer>();
    }
}
