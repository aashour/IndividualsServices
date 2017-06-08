using Tamkeen.IndividualsServices.Core.Data;
using System.Collections.Generic;

namespace Tamkeen.IndividualsServices.Core.Models
{
    public class EconomicActivity: BaseEntity<int>
    {
        public string ActivityName { get; set; }

        public virtual ICollection<Establishment> EstablishmentByMainEconomicActivity { get; set; } = new List<Establishment>();

        public virtual ICollection<Establishment> EstablishmentBySubEconomicActivity { get; set; } = new List<Establishment>();
    }
}
