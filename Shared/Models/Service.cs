using Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public partial class Service : BaseEntity<int>
    {
        public string Name { get; set; }
        public virtual ICollection<OracleTransactionLog> OracleTransactionLogs { get; set; } = new List<OracleTransactionLog>();
        public virtual ICollection<ServiceLog> ServiceLogs { get; set; } = new List<ServiceLog>();

    }
}
