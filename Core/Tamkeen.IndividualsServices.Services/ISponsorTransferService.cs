using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamkeen.IndividualsServices.Services
{
    public interface ISponsorTransferService
    {
        IEnumerable<SponsorTransferRequest> GetByIdNumber(long idNumber);

        SponsorTransferRequest GetById(int laborOfficeId, int year, long sequenceNumber);

        bool UpdateSponsorTransferRequest(int laborOfficeId, int year, long sequenceNumber, long idNumber, SponsorTransferRequestStatusList status);
    }
}
