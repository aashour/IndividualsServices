using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamkeen.IndividualsServices.Services.Models;

namespace Tamkeen.IndividualsServices.Services
{
    public interface IRunawayService
    {
        IEnumerable<RunawayRequest> GetRunawayRequestByIdNumber(string idNumber);
        RunawayRequest GetRunawayRequestById(int id);
    }
}
