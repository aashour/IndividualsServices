using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tamkeen.IndividualsServices.Services;
using Tamkeen.IndividualsServices.WebAPIs.Extensions;

namespace Tamkeen.IndividualsServices.WebAPIs.Controllers
{
    [Route("api/[controller]")]
    public class LaborerController : Controller
    {
        ILaborerService _laborerService;

        public LaborerController(ILaborerService laborerService)
        {
            _laborerService = laborerService;
        }

        // GET: api/Laborer/5
        [HttpGet("GetByIdNumber/{idNumber}")]
        public IActionResult GetByIdNumber(long idNumber)
        {
            var laborer = _laborerService.GetLaborerByIdNumber(idNumber.ToString());

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
