using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class Constants
    {
        public readonly static string BaseAddress = ConfigurationManager.AppSettings["IdSrv:BaseUrl"];// "https://localhost:44300/core";

        public readonly static string AuthorizeEndpoint = BaseAddress + "/connect/authorize";
        public readonly static string LogoutEndpoint = BaseAddress + "/connect/endsession";
        public readonly static string TokenEndpoint = BaseAddress + "/connect/token";
        public readonly static string UserInfoEndpoint = BaseAddress + "/connect/userinfo";
        public readonly static string IdentityTokenValidationEndpoint = BaseAddress + "/connect/identitytokenvalidation";
        public readonly static string TokenRevocationEndpoint = BaseAddress + "/connect/revocation";

        public readonly static string AspNetWebApiSampleApi = ConfigurationManager.AppSettings["WebApi:BaseUrl"]; //"https://localhost:44304/";

        public readonly static string ClientRedirectUri = ConfigurationManager.AppSettings["client:RedirectUri"]; //"http://localhost:44305/";
        public readonly static string ClientLogoutRedirectUri = ConfigurationManager.AppSettings["client:LogoutRedirectUri"]; //"http://localhost:44305/";

    }
}
