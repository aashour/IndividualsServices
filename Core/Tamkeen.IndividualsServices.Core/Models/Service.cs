using Tamkeen.IndividualsServices.Core.Data;
using System.Collections.Generic;

namespace Tamkeen.IndividualsServices.Core.Models
{
    public partial class Service : BaseEntity<int>
    {
        public string Name { get; set; }
        public virtual ICollection<OracleTransactionLog> OracleTransactionLogs { get; set; } = new List<OracleTransactionLog>();
        public virtual ICollection<ServiceLog> ServiceLogs { get; set; } = new List<ServiceLog>();

    }
}
