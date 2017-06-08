using Tamkeen.IndividualsServices.Core.Data;
using System.Collections.Generic;

namespace Tamkeen.IndividualsServices.Core.Models
{
    public partial class Job : BaseEntity<int>
    {
        public string Name { get; set; }
        public bool IsForSaudiOnly { get; set; }
        public string JobCode { get; set; }

        public virtual ICollection<Laborer> Laborers { get; set; } = new List<Laborer>();
        public string Description { get; set; }
    }
}
