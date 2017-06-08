using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models;
using Shared.Data;
using Tamkeen.IndividualsServices.Services.Exceptions;

namespace Tamkeen.IndividualsServices.Services
{
    public class SponsorTransferService : ISponsorTransferService
    {
        IOracleRepository _oracleRepository;
        public SponsorTransferService(IOracleRepository oracleRepository)
        {
            _oracleRepository = oracleRepository;
        }

        public SponsorTransferRequest GetById(int laborOfficeId, int year, long sequenceNumber)
        {
            return _oracleRepository.GetSponsorTransferRequestByRequestNumber(laborOfficeId, year, sequenceNumber);
        }

        public IEnumerable<SponsorTransferRequest> GetByIdNumber(long idNumber)
        {
            return _oracleRepository.GetSponsorTransferRequestByIdNumber(idNumber);
        }

        public bool UpdateSponsorTransferRequest(int laborOfficeId, int year, long sequenceNumber, long idNumber, SponsorTransferRequestStatusList status)
        {
            var updateResult = string.Empty;

            try
            {
                var request = _oracleRepository.GetSponsorTransferRequestByRequestNumber(laborOfficeId, year, sequenceNumber);

                ValidateData(idNumber, request);

                request.Status = status;

                updateResult = _oracleRepository.UpdateSponsorTransferRequest(request, idNumber);
            }
            catch (Exception ex)
            {
                throw;
            }

            return !string.IsNullOrEmpty(updateResult);
        }

        private static void ValidateData(long idNumber, SponsorTransferRequest request)
        {
            if (request == null)
            {
                throw new RequestNotFoundException();
            }

            if (request.IdNumber != idNumber)
            {
                throw new UserNotAuthorizedException();
            }
        }
    }
}
