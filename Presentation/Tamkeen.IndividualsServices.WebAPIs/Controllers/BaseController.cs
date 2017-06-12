using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Tamkeen.IndividualsServices.WebAPIs.Controllers
{
    public class BaseController : Controller
    {
        public User CurrentUser => new User
        {
            IdNumber = long.Parse(HttpContext.User.Claims.First(c => c.Type == "id_number").Value)
        };
    }

    public class User
    {
        public long IdNumber { get; set; }
    }
}
