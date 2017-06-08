using SampleAspNetWebApi.Model;
using System;
using System.Web.Http;
using Tamkeen.IndividualsServices.Services;
using SampleAspNetWebApi.Extensions;

namespace SampleAspNetWebApi.Controllers
{
    public class LaborerController : ApiController
    {
        ILaborerService _laborerService;

        public LaborerController(ILaborerService laborerService)
        {
            _laborerService = laborerService;
        }

        // GET: api/Laborer/5
        [HttpGet]
        [Route("api/Laborer/GetByIdNumber/{idNumber}")]
        public Laborer GetByIdNumber(long idNumber)
        {
            var laborer = _laborerService.GetLaborerByIdNumber(idNumber.ToString());

            if (laborer != null)
            {
                return laborer.ToModel();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
