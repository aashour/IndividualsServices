using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tamkeen.IndividualsServices.Services;
using Tamkeen.IndividualsServices.WebAPIs.Extensions;

namespace Tamkeen.IndividualsServices.WebAPIs.Controllers
{
    [Route("api/[controller]")]
    public class LaborerController : BaseController
    {
        ILaborerService _laborerService;

        public LaborerController(ILaborerService laborerService)
        {
            _laborerService = laborerService;
        }

        [HttpGet]
        public IActionResult Get()
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
