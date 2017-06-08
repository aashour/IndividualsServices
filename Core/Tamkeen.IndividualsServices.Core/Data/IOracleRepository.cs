using System.Collections.Generic;
using Tamkeen.IndividualsServices.Core.Models;

namespace Tamkeen.IndividualsServices.Core.Data
{
    public interface IOracleRepository
    {
        IEnumerable<SponsorTransferRequest> GetSponsorTransferRequestByIdNumber(long idNumber);

        SponsorTransferRequest GetSponsorTransferRequestByRequestNumber(int laborOfficeId, int year, long sequenceNumber);

        string UpdateSponsorTransferRequest(SponsorTransferRequest request, long userIdNumber);
    }
}
