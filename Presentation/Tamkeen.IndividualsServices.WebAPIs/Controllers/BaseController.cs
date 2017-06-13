using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Authentication;

namespace Tamkeen.IndividualsServices.WebAPIs.Controllers
{
    public class BaseController : Controller
    {
        public User CurrentUser
        {
            get
            {
                if (HttpContext.User != null && HttpContext.User.Identity != null && User.Identity.IsAuthenticated)
                {
                    return new User
                    {
                        IdNumber = long.Parse(HttpContext.User.FindFirst("id_number").Value)
                    };
                }
                else
                {
                    throw new AuthenticationException();
                }
            }
        }


        //page not found
        public virtual IActionResult PageNotFound()
        {

            this.Response.StatusCode = 404;
            this.Response.ContentType = "text/html";

            return View();
        }

        //Unauthorized
        public virtual IActionResult Unauthorized()
        {

            this.Response.StatusCode = 401;
            this.Response.ContentType = "text/html";

            return View();
        }
    }

    public class User
    {
        public long IdNumber { get; set; }
    }
}
