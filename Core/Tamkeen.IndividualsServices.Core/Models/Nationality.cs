using Tamkeen.IndividualsServices.Core.Data;
using System.Collections.Generic;

namespace Tamkeen.IndividualsServices.Core.Models
{
    public partial class Nationality : BaseEntity<short>
    {

        public string Name { get; set; }

        public string NameEN { get; set; }

        public bool? IsIncludedForEWV { get; set; }

        public virtual ICollection<Laborer> Laborers { get; set; } = new List<Laborer>();
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
