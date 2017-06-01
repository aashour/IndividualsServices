using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamkeen.IndividualsServices.Services
{
    public interface INitaqatService
    {
        EstablishmentKPI GetEstablishmentDetails(int laborOfficeId, long sequenceNumber);
    }
}
