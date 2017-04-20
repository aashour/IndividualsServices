using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace IdentityServer3.Host.Config
{
    public class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                /////////////////////////////////////////////////////////////
                // Client Credentials With Jwt Token
                /////////////////////////////////////////////////////////////
                new Client
                {
                    ClientId = "implicit client",
                    ClientName = "Individual services Implicit Client",
                    Enabled = true,
                    Flow = Flows.Implicit,                    

                    RequireConsent = true,
                    AllowRememberConsent = true,

                    RedirectUris = 
                        new List<string> {"https://localhost:44304/account/signInCallback"},
                    PostLogoutRedirectUris =
                        new List<string> {"https://localhost:44304/"},
                    
                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        Constants.StandardScopes.Email,
                        Constants.StandardScopes.Roles,
                        Constants.StandardScopes.OfflineAccess,
                        "read",
                        "write"
                    },

                    AccessTokenType = AccessTokenType.Jwt,

                    //ClientUri=,
                    //LogoUri=,
                    //IdentityTokenLifetime=,
                    //AccessTokenLifetime=,
                    //AbsoluteRefreshTokenLifetime=,
                },
            };
        }
    }
}