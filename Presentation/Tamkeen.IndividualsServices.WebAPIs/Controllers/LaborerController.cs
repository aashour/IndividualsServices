using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tamkeen.IndividualsServices.Services;
using Tamkeen.IndividualsServices.WebAPIs.Extensions;
using System.Linq;

namespace Tamkeen.IndividualsServices.WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class LaborerController : BaseController
    {
        ILaborerService _laborerService;

        public LaborerController(ILaborerService laborerService)
        {
            _laborerService = laborerService;
        }

        // GET: api/Laborer/2222222222
        [HttpGet]
        public IActionResult GetByIdNumber()
        {
            var laborer = _laborerService.GetLaborerByIdNumber(CurrentUser.IdNumber);

            if (laborer != null)
            {
                var laborerJson = laborer.ToDto();
                return Json(laborerJson);
            }
            else
            {
                return new NotFoundResult();
            }
        }
    }
}
