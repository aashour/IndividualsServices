using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public partial class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsForSaudiOnly { get; set; }
        public string JobCode { get; set; }

        public virtual ICollection<Laborer> Laborers { get; set; } = new List<Laborer>();
    }
}
