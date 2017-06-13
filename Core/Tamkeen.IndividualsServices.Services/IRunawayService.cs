using System.Collections.Generic;
using Tamkeen.IndividualsServices.Core.Models;
using Tamkeen.IndividualsServices.Services.Models;

namespace Tamkeen.IndividualsServices.Services
{
    public interface IRunawayService
    {
        IEnumerable<RunawayRequest> GetRunawayRequestByIdNumber(long idNumber);
        RunawayRequest GetRunawayRequestById(int requestId);

        RunawayComplaint GetRunawayComplaintById(int complaintId);
    }
}
