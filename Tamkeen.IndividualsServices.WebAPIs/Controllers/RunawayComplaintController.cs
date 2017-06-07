using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tamkeen.IndividualsServices.Services;
using Tamkeen.IndividualsServices.WebAPIs.Common;
using Tamkeen.IndividualsServices.WebAPIs.Extensions;
using Tamkeen.IndividualsServices.WebAPIs.Models;

namespace Tamkeen.IndividualsServices.WebAPIs.Controllers
{
    [Route("api/[controller]")]
    public class RunawayComplaintController : Controller
    {
        private readonly int _maxFileSize = 1024 * 1024;
        private readonly string[] _fileExtensions = new string[] { ".doc", ".docx", ".ppt", ".pptx", ".txt", ".xls", ".xlsx", ".png", ".jpg", ".jpeg", ".pdf" };
        private int _maxFilesCount = 10;

        IRunawayService _runawayService;
        public RunawayComplaintController(IRunawayService runawayService)
        {
            _runawayService = runawayService;
        }

        [HttpPost]
        public IActionResult Post([FromForm]CreateRunawayComplaintDto runawayComplaint)
        {
            var attachedFiles = Request.Form.Files.Where(f => !string.IsNullOrEmpty(f.FileName));

            if (attachedFiles.Count() > _maxFilesCount)
            {
                return BadRequest(new ErrorResponse("1", "Maximum allawed attachemnts is 10"));
            }

            foreach (var attachedFile in attachedFiles)
            {
                if (attachedFile.Length > _maxFileSize)
                {
                    return BadRequest(new ErrorResponse("2", "Mximum allawed file size is 2MB"));
                }

                if (_fileExtensions.Contains(System.IO.Path.GetExtension(attachedFile.FileName)) == false)
                {
                    return BadRequest(new ErrorResponse("3", "Invalid file type"));
                }
            }

            return Json(new
            {
                IdNumber = runawayComplaint.IdNumber,
                Reason = runawayComplaint.Reason,
                Files = attachedFiles.Select(f => new
                {
                    Size = f.Length / 1024,
                    FileName = f.FileName,
                    ContentType = f.ContentType
                })
            });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var runawayComplaint = _runawayService.GetRunawayComplaintById(id);

            if (runawayComplaint != null)
            {

                return Json(runawayComplaint.ToDto());
            }
            else
            {
                return new NotFoundResult();
            }
        }
    }
}
