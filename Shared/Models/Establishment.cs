using Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public partial class Establishment : BaseEntity<long>
    {
        public long UnifiedNumberId { get; set; }
        public int LaborOfficeId { get; set; }
        public long SequenceNumber { get; set; }
        public string Name { get; set; }
        public string CommercialRecordNumber { get; set; }
        public int? StatusId { get; set; }
        public virtual UnifiedNumber UnifiedNumber { get; set; }
        public virtual EstablishmentStatus Status { get; set; }
        public virtual LaborOffice LaborOffice { get; set; }
        public virtual ICollection<Laborer> Laborers { get; set; } = new List<Laborer>();       
        public virtual ICollection<OracleTransactionLog> OracleTransactionLogs { get; set; } = new List<OracleTransactionLog>();
        public int? MainEconomicActivityId { get; set; }
        public virtual EconomicActivity MainEconomicActivity { get; set; }
        public int? SubEconomicActivityId { get; set; }
        public virtual EconomicActivity SubEconomicActivity { get; set; }
        public string Email { get; set; }
        public WaselAddress Wasel { get; set; } 
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public ICollection<ServiceLog> ServiceLogs { get; set; }
        public ICollection<RunawayComplaint> RunawayComplaints { get; set; }
    }
}
