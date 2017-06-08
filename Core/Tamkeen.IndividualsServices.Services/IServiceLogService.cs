using Tamkeen.IndividualsServices.Core.DataStructure;
using Tamkeen.IndividualsServices.Core.Models;

namespace Tamkeen.IndividualsServices.Services
{
    public interface IServiceLogService
    {
        IPagedList<ServiceLog> SearchServiceLog(int serviceLogId = 0, long establishmentId = 0, long laborerId = 0, string requesterIdNo = "",
            int pageIndex = 0, int pageSize = int.MaxValue);

        IPagedList<ServiceLog> ServiceLogForLaborer(long laborerIdNo, int pageIndex = 0, int pageSize = int.MaxValue);
    }
}
