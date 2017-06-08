using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public enum SponsorTransferRequestStatusList
    {
        Pending = 1,
        Rejected = 2,
        Approved = 3,
        ApprovedByLaborer = 6,
        RejctedByLaborer = 7
    }
}
