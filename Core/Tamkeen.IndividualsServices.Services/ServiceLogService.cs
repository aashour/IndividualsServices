﻿using System;
using System.Linq;
using Tamkeen.IndividualsServices.Core.DataStructure;
using Tamkeen.IndividualsServices.Core.Models;
using Tamkeen.IndividualsServices.Core.Data;

namespace Tamkeen.IndividualsServices.Services
{
    public class ServiceLogService : IServiceLogService
    {

        private readonly IRepository<ServiceLog, int> _serviceLogRepository;

        public ServiceLogService(IRepository<ServiceLog, int> serviceLogRepository)
        {
            this._serviceLogRepository = serviceLogRepository;
        }

        public IPagedList<ServiceLog> SearchServiceLog(int serviceLogId = 0, long establishmentId = 0, long laborerId = 0, string requesterIdNo = "",
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
            if (!string.IsNullOrWhiteSpace(requesterIdNo))
            {
                query = from service in query
                        where service.RequesterIdNo == requesterIdNo
                        select service;
            }

            //paging
            return new PagedList<ServiceLog>(query.OrderBy(x => x.Id), pageIndex, pageSize);
        }

        public IPagedList<ServiceLog> ServiceLogForLaborer(long laborerIdNo, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _serviceLogRepository.Table;

            query = from service in query
                    where service.Laborer.IdNo.Equals(laborerIdNo.ToString(), StringComparison.OrdinalIgnoreCase)
                    select service;

            //paging
            return new PagedList<ServiceLog>(query.OrderBy(x => x.Id), pageIndex, pageSize);
        }
    }
}
