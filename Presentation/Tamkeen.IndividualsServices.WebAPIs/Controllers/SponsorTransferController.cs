using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tamkeen.IndividualsServices.WebAPIs.Models;
using Tamkeen.IndividualsServices.Services;
using Tamkeen.IndividualsServices.WebAPIs.Extensions;

namespace Tamkeen.IndividualsServices.WebAPIs.Controllers
{
    [Route("api/[controller]")]
    public class SponsorTransferController : Controller
    {
        ISponsorTransferService _sponsorTransferService;

        public SponsorTransferController(ISponsorTransferService sponsorTransferService)
        {
            _sponsorTransferService = sponsorTransferService;
        }

        // GET: api/Laborer/5
        [HttpGet("{idNumber}")]
        public IActionResult Get(long idNumber)
        {
            var sponsorTransferReqeusts = _sponsorTransferService.GetByIdNumber(idNumber);

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

        [HttpPost("{idNumber}")]
        public IActionResult Post([FromForm] UpdateSponsorTransferRequestDto request, long idNumber)
        {
            var result = false;

            if (request != null)
            {
                if (request.Action == SponsorTransferRequestAction.Approve)
                {
                    result = _sponsorTransferService.UpdateSponsorTransferRequest(request.LaborOfficeId, request.Year, request.SequenceNumber, idNumber, Shared.Models.SponsorTransferRequestStatusList.ApprovedByLaborer);
                }
                else
                {
                    result = _sponsorTransferService.UpdateSponsorTransferRequest(request.LaborOfficeId, request.Year, request.SequenceNumber, idNumber, Shared.Models.SponsorTransferRequestStatusList.RejctedByLaborer);
                }
            }

            return (result == true) ? Ok() : new StatusCodeResult(500);
        }
    }
}
