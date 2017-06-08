using Tamkeen.IndividualsServices.Core.Data;
using System.Collections.Generic;

namespace Tamkeen.IndividualsServices.Core.Models
{
    public partial class LaborerStatus : BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Laborer> Laborers { get; set; } = new List<Laborer>();
    }
}
