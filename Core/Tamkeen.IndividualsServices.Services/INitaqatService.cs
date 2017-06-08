using Tamkeen.IndividualsServices.Core.Models;

namespace Tamkeen.IndividualsServices.Services
{
    public interface INitaqatService
    {
        EstablishmentKPI GetEstablishmentDetails(int laborOfficeId, long sequenceNumber);
    }
}
