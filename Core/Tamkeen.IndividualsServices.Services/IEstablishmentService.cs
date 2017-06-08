using Tamkeen.IndividualsServices.Core.Models;
using System.Collections.Generic;

namespace Tamkeen.IndividualsServices.Services
{
    public interface IEstablishmentService
    {
        Establishment GetEstablishment(long id);
        IEnumerable<UserEstablishment> GetUserEstablishmentsByEstablishmentId(long establishmentId);
    }
}
