using System.Collections.Generic;
using Tamkeen.IndividualsServices.Services.Models;

namespace Tamkeen.IndividualsServices.Services
{
    public interface IRunawayService
    {
        IEnumerable<RunawayRequest> GetRunawayRequestByIdNumber(string idNumber);
        RunawayRequest GetRunawayRequestById(int requestId);

        RunawayComplaint GetRunawayComplaintById(int complaintId);
    }
}
