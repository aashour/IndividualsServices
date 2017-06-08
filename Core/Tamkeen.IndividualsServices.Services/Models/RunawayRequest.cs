using Tamkeen.IndividualsServices.Core.Models;
using System;

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
