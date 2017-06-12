using Microsoft.AspNetCore.Mvc;

namespace Tamkeen.IndividualsServices.WebAPIs.Controllers
{
    public class CommonController : Controller
    {
        //page not found
        public virtual IActionResult PageNotFound()
        {

            this.Response.StatusCode = 404;
            this.Response.ContentType = "text/html";

            return View();
        }
    }
}
