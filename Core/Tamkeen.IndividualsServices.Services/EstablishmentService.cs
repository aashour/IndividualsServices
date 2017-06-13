using System.Collections.Generic;
using System.Linq;
using Tamkeen.IndividualsServices.Core.Models;
using Tamkeen.IndividualsServices.Core.Data;

namespace Tamkeen.IndividualsServices.Services
{
    public class EstablishmentService : IEstablishmentService
    {
        private readonly IRepository<Establishment, long> _establishmentRepository;
        private readonly IRepository<UserEstablishment, long> _userEstablishmentRepository;

        public EstablishmentService(IRepository<Establishment, long> establishmentRepository, IRepository<UserEstablishment, long> userEstablishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
            _userEstablishmentRepository = userEstablishmentRepository;
        }

        public Establishment GetEstablishment(long establishmentId)
        {           
            return _establishmentRepository.GetById(establishmentId);
        }

        public IEnumerable<UserEstablishment> GetUserEstablishmentsByEstablishmentId(long establishmentId)
        {
            return _userEstablishmentRepository.Table.Where(u => u.EstablishmentId == establishmentId).ToList();
        }
    }
}
