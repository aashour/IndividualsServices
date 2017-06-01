using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Tamkeen.IndividualsServices.Services;
using Tamkeen.IndividualsServices.WebAPIs.Models;
using Tamkeen.IndividualsServices.WebAPIs.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tamkeen.IndividualsServices.WebAPIs.Controllers
{
    [Route("api/[controller]")]
    public class EstablishmentController : Controller
    {
        IEstablishmentService _establishmentService;
        INitaqatService _nitaqatService;

        public EstablishmentController(IEstablishmentService establishmentService, INitaqatService nitaqatService)
        {
            _establishmentService = establishmentService;
            _nitaqatService = nitaqatService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var establishment = _establishmentService.GetEstablishment(id);

            if (establishment != null)
            {
                var establishmentKpi = _nitaqatService.GetEstablishmentDetails(establishment.LaborOfficeId, establishment.SequenceNumber);
                var userEstablishmnts = _establishmentService.GetUserEstablishmentsByEstablishmentId(establishment.Id);

                return Json(establishment.ToDto(establishmentKpi, userEstablishmnts?
                                                                    .Where(u => u.IsVerified == true)
                                                                    .OrderBy(u => u.TypeId)
                                                                    .FirstOrDefault()));

            }
            else
            {
                return new NotFoundResult();
            }
        }
    }
}
