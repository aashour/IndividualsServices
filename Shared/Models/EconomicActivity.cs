using Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class EconomicActivity: BaseEntity<int>
    {
        public string ActivityName { get; set; }

        public virtual ICollection<Establishment> EstablishmentByMainEconomicActivity { get; set; } = new List<Establishment>();

        public virtual ICollection<Establishment> EstablishmentBySubEconomicActivity { get; set; } = new List<Establishment>();
    }
}
