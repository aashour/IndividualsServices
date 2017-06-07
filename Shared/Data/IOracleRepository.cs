using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Data
{
    public interface IOracleRepository
    {
        IEnumerable<SponsorTransferRequest> GetSponsorTransferRequestByIdNumber(long idNumber);

        SponsorTransferRequest GetSponsorTransferRequestByRequestNumber(int laborOfficeId, int year, long sequenceNumber);

        string UpdateSponsorTransferRequest(SponsorTransferRequest request, long userIdNumber);
    }
}
