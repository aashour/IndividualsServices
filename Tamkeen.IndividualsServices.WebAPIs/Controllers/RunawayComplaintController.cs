using Microsoft.AspNetCore.Mvc;
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
    public class RunawayComplaintController : Controller
    {
        private readonly int _maxFileSize = 1024 * 1024;
        private readonly string[] _fileExtensions = new string[] { ".doc", ".docx", ".ppt", ".pptx", ".txt", ".xls", ".xlsx", ".png", ".jpg", ".jpeg", ".pdf" };
        private int _maxFilesCount = 10;

        [HttpPost()]
        public IActionResult Post([FromForm]CreateRunawayComplaintDto runawayComplaint)
        {
            var attachedFiles = HttpContext.Request.Form.Files.Where(f => !string.IsNullOrEmpty(f.FileName));

            if (attachedFiles.Count() > _maxFilesCount)
            {
                return BadRequest("Maximum allawed attachemnts is 10");
            }

            foreach (var attachedFile in attachedFiles)
            {
                if (attachedFile.Length > _maxFileSize)
                {
                    return BadRequest("Mximum allawed file size is 2MB");
                }

                if (_fileExtensions.Contains(System.IO.Path.GetExtension(attachedFile.FileName)) == false)
                {
                    return BadRequest("Invalid file type");
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
    }
}
