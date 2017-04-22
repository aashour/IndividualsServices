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
                    ClientId = "implicit.client",
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
                        "write",
                        "webApi"
                    },

                    AccessTokenType = AccessTokenType.Jwt,
                    
                    //IdentityTokenLifetime=,
                    //AccessTokenLifetime =,
                    //ClientUri=,
                    //LogoUri=,
                    //IdentityTokenLifetime=,
                    //AccessTokenLifetime=,
                    //AbsoluteRefreshTokenLifetime=,
                },

                 // no human involved
                new Client
                {
                    ClientName = "Silicon-only Client",
                    ClientId = "silicon",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ClientCredentials,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("F621F470-9731-4A25-80EF-67A6F7C5F4B8".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "webApi"
                    }
                },

                 // human is involved
                new Client
                {
                    ClientName = "Silicon on behalf of Carbon Client",
                    ClientId = "carbon",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ResourceOwner,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("21B5F798-BE55-42BC-8AA8-0025B903DC3B".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "webApi"
                    }
                }
            };
        }
    }
}