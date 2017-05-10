using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataStructure;
using Shared.Models;
using Shared.Data;

namespace Tamkeen.IndividualsServices.Services
{
    public class ServiceLogService : IServiceLogService
    {

        private readonly IRepository<ServiceLog, int> _serviceLogRepository;

        public ServiceLogService(IRepository<ServiceLog, int> serviceLogRepository)
        {
            this._serviceLogRepository = serviceLogRepository;
        }

        public IPagedList<ServiceLog> SearchServiceLog(int serviceLogId = 0, long establishmentId = 0, long laborerId = 0, long requesterIdNo = 0,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _serviceLogRepository.Table;

            if (serviceLogId > 0)
            {
                query = from service in query
                        where service.Id == serviceLogId
                        select service;
            }
            if (establishmentId > 0)
            {
                query = from service in query
                        where service.EstablishmentId == establishmentId
                        select service;
            }
            if (laborerId > 0)
            {
                query = from service in query
                        where service.LaborerId == laborerId
                        select service;
            }
            if (requesterIdNo > 0)
            {
                query = from service in query
                        where service.RequesterIdNo == requesterIdNo
                        select service;
            }

            //paging
            return new PagedList<ServiceLog>(query.ToList(), pageIndex, pageSize);
        }

        public IPagedList<ServiceLog> ServiceLogForLaborer(long laborerIdNo, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _serviceLogRepository.Table;

            query = from service in query
                    where service.Laborer.IdNo.Equals(laborerIdNo.ToString(), StringComparison.OrdinalIgnoreCase)
                    select service;

            //paging
            return new PagedList<ServiceLog>(query.ToList(), pageIndex, pageSize);
        }
    }
}
