using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Tamkeen.IndividualsServices.WebAPIs.Models;
using Tamkeen.IndividualsServices.Services;
using Tamkeen.IndividualsServices.WebAPIs.Extensions;
using Microsoft.AspNetCore.Authorization;
using Tamkeen.IndividualsServices.Core.Models;

namespace Tamkeen.IndividualsServices.WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class SponsorTransferController : BaseController
    {
        ISponsorTransferService _sponsorTransferService;

        public SponsorTransferController(ISponsorTransferService sponsorTransferService)
        {
            _sponsorTransferService = sponsorTransferService;
        }

        // GET: api/Laborer/5
        [HttpGet]
        public IActionResult Get()
        {
            var sponsorTransferReqeusts = _sponsorTransferService.GetByIdNumber(CurrentUser.IdNumber);

            if (sponsorTransferReqeusts != null && sponsorTransferReqeusts.Any())
            {
                return Json(sponsorTransferReqeusts.ToDto());
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [HttpGet("{laborOfficeId}/{year}/{sequenceNumber}")]
        public IActionResult Get(int laborOfficeId, int year, long sequenceNumber)
        {
            var sponsorTransferReqeust = _sponsorTransferService.GetById(laborOfficeId, year, sequenceNumber);

            if (sponsorTransferReqeust != null)
            {
                return Json(sponsorTransferReqeust.ToDto());
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [HttpPost]
        public IActionResult Post([FromForm] UpdateSponsorTransferRequestDto request)
        {
            var result = false;

            if (request != null)
            {
                if (request.Action == SponsorTransferRequestAction.Approve)
                {
                    result = _sponsorTransferService.UpdateSponsorTransferRequest(request.LaborOfficeId, request.Year, request.SequenceNumber, CurrentUser.IdNumber, SponsorTransferRequestStatusList.ApprovedByLaborer);
                }
                else
                {
                    result = _sponsorTransferService.UpdateSponsorTransferRequest(request.LaborOfficeId, request.Year, request.SequenceNumber, CurrentUser.IdNumber, SponsorTransferRequestStatusList.RejctedByLaborer);
                }
            }

            return (result == true) ? Ok() : new StatusCodeResult(500);
        }
    }
}
