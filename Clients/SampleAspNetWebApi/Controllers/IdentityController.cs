using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace SampleAspNetWebApi.Controllers
{
    [Authorize]
    public class IdentityController : ApiController
    {
        public IHttpActionResult Get()
        {
            var caller = User as ClaimsPrincipal;

            var claims = from c in caller.Claims
                         select new
                         {
                             type = c.Type,
                             value = c.Value
                         };

            var subjectClaim = caller.FindFirst("sub");
            if (subjectClaim != null)
            {

                return Json(claims);

                return Json(new
                {
                    message = "OK user",
                    client = caller.FindFirst("client_id").Value,
                    subject = subjectClaim.Value
                });
            }
            else
            {

                return Json(claims);
                return Json(new
                {
                    message = "OK computer",
                    client = caller.FindFirst("client_id").Value
                });
            }

            //return from c in principal.Identities.First().Claims
            //       select new
            //       {
            //           c.Type,
            //           c.Value
            //       };
        }
    }
}