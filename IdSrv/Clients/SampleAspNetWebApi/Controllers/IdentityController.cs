using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace SampleAspNetWebApi.Controllers
{
    public class IdentityController : ApiController
    {
        [HttpOptions]
        public HttpResponseMessage Options()
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Methods", "GET");
            return response;
        }

        [Authorize]
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

                //return Json(new
                //{
                //    message = "OK user",
                //    client = caller.FindFirst("client_id").Value,
                //    subject = subjectClaim.Value
                //});
            }
            else
            {

                return Json(claims);
                //return Json(new
                //{
                //    message = "OK computer",
                //    client = caller.FindFirst("client_id").Value
                //});
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