using Shared.DataStructure;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamkeen.IndividualsServices.Services
{
    public interface IServiceLogService
    {
        IPagedList<ServiceLog> SearchServiceLog(int serviceLogId = 0, long establishmentId = 0, long laborerId = 0, long requesterIdNo = 0,
            int pageIndex = 0, int pageSize = int.MaxValue);

        IPagedList<ServiceLog> ServiceLogForLaborer(long laborerIdNo, int pageIndex = 0, int pageSize = int.MaxValue);
    }
}
