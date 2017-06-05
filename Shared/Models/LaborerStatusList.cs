using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public enum LaborerStatusList
    {
        Working = 1,
        WorkingNoStatistics = 2,
        Runner = 3,
        Suspended = 4,
        FinalExit = 5,
        Dead = 6,
        ServiceEnd = 7,
        Transfered = 8,
        ChangeWorkStatus = 9,
        SponsorTransfer = 10,
        ChangeJobDescription = 11
    }
}
