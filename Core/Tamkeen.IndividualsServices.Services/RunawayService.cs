using System.Collections.Generic;
using System.Linq;
using Tamkeen.IndividualsServices.Core.Models;
using Tamkeen.IndividualsServices.Core.Data;
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

        public IEnumerable<RunawayRequest> GetRunawayRequestByIdNumber(long idNumber)
        {

            var allServiceLogs = _serviceLogRepository.Table.Where(s => s.Laborer.IdNo == idNumber.ToString()
                                                                    && (s.ServiceId == (int)ServiceList.LaborRunAwayService
                                                                        || s.ServiceId == (int)ServiceList.CancelRunaway)).ToList();

            if (!allServiceLogs.Any())
            {
                return null;
            }

            var runawayRequests = allServiceLogs
                     .Where(s => s.ServiceId == (int)ServiceList.LaborRunAwayService)
                     .Select(s =>
                         {
                             RunawayRequest runawayRequest = MapRunawayRequest(s);

                             runawayRequest.Status = RunawayRequestStatusList.Cancelled;
                             runawayRequest.CancellationReason = RunawayCancellationReasonList.Establishment;
                             runawayRequest.CancellationDate = allServiceLogs.Where(sl => sl.CreationDate > s.CreationDate && sl.ServiceId == (int)ServiceList.CancelRunaway).OrderBy(sl => sl.CreationDate).FirstOrDefault().CreationDate;

                             return runawayRequest;
                         }).ToList();


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

            return runawayRequests;
        }

        private RunawayRequest MapRunawayRequest(ServiceLog serviceLog)
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
            var runawayRequest = _serviceLogRepository.Table.Where(s => s.Id == runawayRequestId).SingleOrDefault();

            if (runawayRequest == null)
            {
                return null;               
            }

            return MapRunawayRequest(runawayRequest);
        }

        public RunawayComplaint GetRunawayComplaintById(int complaintId)
        {
            return _runawayComplaintRepository.Table.Where(c => c.Id == complaintId).SingleOrDefault();
        }
    }
}
