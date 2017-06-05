﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tamkeen.IndividualsServices.Services;
using Tamkeen.IndividualsServices.WebAPIs.Extensions;
using Tamkeen.IndividualsServices.WebAPIs.Models;

namespace Tamkeen.IndividualsServices.WebAPIs.Controllers
{
    [Route("api/[controller]")]
    public class RunawayController : Controller
    {
        IRunawayService _runawayService;

        public RunawayController(IRunawayService runawayService)
        {
            _runawayService = runawayService;
        }

        [HttpGet("GetByIdNumber/{idNumber}")]
        public IActionResult GetByIdNumber(long idNumber)
        {
            var runawayRequests = _runawayService.GetRunawayRequestByIdNumber(idNumber.ToString());

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

            return Json(
                runawayRequest.ToDto());
        }
    }
}
