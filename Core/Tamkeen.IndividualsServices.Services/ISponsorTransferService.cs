using System.Collections.Generic;
using Tamkeen.IndividualsServices.Core.Models;

namespace Tamkeen.IndividualsServices.Services
{
    public interface ISponsorTransferService
    {
        IEnumerable<SponsorTransferRequest> GetByIdNumber(long idNumber);

        SponsorTransferRequest GetById(int laborOfficeId, int year, long sequenceNumber);

        bool UpdateSponsorTransferRequest(int laborOfficeId, int year, long sequenceNumber, long idNumber, SponsorTransferRequestStatusList status);
    }
}
