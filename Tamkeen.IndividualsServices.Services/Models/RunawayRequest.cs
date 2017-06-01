using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamkeen.IndividualsServices.Services.Models
{
    public class RunawayRequest : ServiceLog
    {
        public DateTime CancellationDate { get; set; }
        public RunawayRequestStatusList Status { get; set; }
        public DateTime RunawayDate { get; set; }
        public RunawayCancellationReasonList CancellationReason { get; set; }

    }
}
