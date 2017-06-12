using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
