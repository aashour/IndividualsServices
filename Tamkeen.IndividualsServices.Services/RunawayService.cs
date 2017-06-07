using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects;
using System.Text;
using System.Threading.Tasks;
using Shared.Models;
using Shared.Data;
using Tamkeen.IndividualsServices.Services.Models;

namespace Tamkeen.IndividualsServices.Services
{
    public class RunawayService : IRunawayService
    {
        private readonly IRepository<ServiceLog, int> _serviceLogRepository;
        private readonly IRepository<RunawayComplaint, int> _runawayComplaintRepository;

        public RunawayService(IRepository<ServiceLog, int> serviceLogRepository, IRepository<RunawayComplaint, int> runawayComplaintRepository)
        {
            _serviceLogRepository = serviceLogRepository;
            _runawayComplaintRepository = runawayComplaintRepository;
        }
        public IEnumerable<RunawayRequest> GetRunawayRequestByIdNumber(string idNumber)
        {
            var query = from serviceLog in _serviceLogRepository.Table
                        where serviceLog.Laborer.IdNo == idNumber &&
                            (serviceLog.ServiceId == (int)ServiceList.LaborRunAwayService || serviceLog.ServiceId == (int)ServiceList.CancelRunaway)
                        orderby serviceLog.CreationDate descending
                        select serviceLog;



            var runawayRequests = new List<RunawayRequest>();

            if (query.Any())
            {
                var allServiceLogs = query.ToList();

                foreach (var serviceLog in allServiceLogs)
                {
                    if (serviceLog.ServiceId == (int)ServiceList.LaborRunAwayService)
                    {
                        RunawayRequest runawayRequest = MapRunawayRequest(serviceLog);

                        runawayRequest.Status = RunawayRequestStatusList.Cancelled;
                        runawayRequest.CancellationReason = RunawayCancellationReasonList.Establishment;
                        runawayRequest.CancellationDate = allServiceLogs.Where(sl => sl.CreationDate > serviceLog.CreationDate && sl.ServiceId == (int)ServiceList.CancelRunaway).OrderBy(sl => sl.CreationDate).FirstOrDefault().CreationDate;

                        runawayRequests.Add(runawayRequest);
                    }
                }


                if (runawayRequests.Any())
                {
                    var laborer = allServiceLogs.First().Laborer;

                    if (laborer.StatusId == (int)LaborerStatusList.Runner)
                    {
                        runawayRequests.First().Status = RunawayRequestStatusList.Active;
                    }
                    else if (laborer.StatusId == (int)LaborerStatusList.Working
                        && runawayRequests.First().CancellationDate == null
                        && laborer.LaborerStatusModificationDate.HasValue)
                    {
                        runawayRequests.First().CancellationDate = laborer.LaborerStatusModificationDate.Value;
                    }
                }
            }

            return runawayRequests;
        }

        private static RunawayRequest MapRunawayRequest(ServiceLog serviceLog)
        {
            return new RunawayRequest
            {
                CreationDate = serviceLog.CreationDate,
                Establishment = serviceLog.Establishment,
                EstablishmentId = serviceLog.EstablishmentId,
                Id = serviceLog.Id,
                Laborer = serviceLog.Laborer,
                LaborerId = serviceLog.LaborerId,
                Requester = serviceLog.Requester,
                RequesterIdNo = serviceLog.RequesterIdNo,
                RunawayDate = serviceLog.CreationDate,
                Service = serviceLog.Service,
                ServiceId = serviceLog.ServiceId,
                UserId = serviceLog.UserId,
                RunawayComplaints = serviceLog.RunawayComplaints
            };
        }

        public RunawayRequest GetRunawayRequestById(int runawayRequestId)
        {
            var runawayRequest = _serviceLogRepository.Table.Where(s=>s.Id== runawayRequestId).SingleOrDefault();

            if (runawayRequest != null)
            {
                return MapRunawayRequest(runawayRequest);
            }
            else
            {
                return null;
            }
        }

        public RunawayComplaint GetRunawayComplaintById(int complaintId)
        {
            return _runawayComplaintRepository.Table.Where(c => c.Id == complaintId).SingleOrDefault();
        }
    }
}
