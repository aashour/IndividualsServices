using Microsoft.AspNetCore.Mvc;
using Tamkeen.IndividualsServices.Services;
using Tamkeen.IndividualsServices.WebAPIs.Extensions;

namespace Tamkeen.IndividualsServices.WebAPIs.Controllers
{
    [Route("api/[controller]")]
    public class RunawayController : BaseController
    {
        IRunawayService _runawayService;

        public RunawayController(IRunawayService runawayService)
        {
            _runawayService = runawayService;
        }

        [HttpGet()]
        public IActionResult GetByIdNumber()
        {
            var runawayRequests = _runawayService.GetRunawayRequestByIdNumber(CurrentUser.IdNumber);

            if (runawayRequests != null)
            {
                return Json(runawayRequests.ToDto());
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var runawayRequest = _runawayService.GetRunawayRequestById(id);

            if (runawayRequest == null)
            {
                return NotFound();
            }

            if (runawayRequest.Laborer?.IdNo != CurrentUser.IdNumber.ToString())
            {
                return Unauthorized();
            }

            return Json(runawayRequest.ToDto());
        }
    }
}
