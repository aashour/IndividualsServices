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
            var query = from establishment in _establishmentRepository.Table
                        where establishment.Id == establishmentId
                        select establishment;

            return query.FirstOrDefault();
        }

        public IEnumerable<UserEstablishment> GetUserEstablishmentsByEstablishmentId(long establishmentId)
        {
            var query = from userEstablishment in _userEstablishmentRepository.Table
                        where userEstablishment.EstablishmentId == establishmentId 
                        select userEstablishment;

            return query.ToList();
        }
    }
}
