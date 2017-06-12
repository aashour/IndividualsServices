using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace IdentityServer3.Host.Config
{
    public class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            var scopes = new List<Scope>
                {
                    new Scope
                    {
                        Enabled = true,
                        Name = "roles",
                        Type = ScopeType.Identity,
                        Claims = new List<ScopeClaim>
                        {
                            new ScopeClaim("role")
                        }
                    },
                    new Scope
                    {
                        Name = "Tamkeen.IndividualsServices.WebAPIs",
                         DisplayName = "access web api",
                        Type = ScopeType.Resource,
                        Claims = new List<ScopeClaim>
                        {
                            new ScopeClaim(Constants.ClaimTypes.Name),
                            new ScopeClaim(Constants.ClaimTypes.Role),
                            new ScopeClaim(Constants.ClaimTypes.Email, alwaysInclude:true),
                            new ScopeClaim("id_number"),
                            new ScopeClaim("birth_date")
                        },

                        ScopeSecrets = new List<Secret>
                        {
                            new Secret("secret".Sha256())
                        }
                    },
                    new Scope
                    {
                        Name = "read",
                        DisplayName = "Read data",
                        Type = ScopeType.Resource,
                        Emphasize = false,

                        ScopeSecrets = new List<Secret>
                        {
                            new Secret("secret".Sha256())
                        },
                        Claims=new List<ScopeClaim>{
                            new ScopeClaim(Constants.ClaimTypes.Email),
                            new ScopeClaim("first_name"),
                            new ScopeClaim("fourth_name"),
                            new ScopeClaim("id_number"),
                            new ScopeClaim("iqama_expiry_date"),
                            new ScopeClaim("birth_date")
                        },
                    },
                    new Scope
                    {
                        Name = "write",
                        DisplayName = "Write data",
                        Type = ScopeType.Resource,
                        Emphasize = true,

                        ScopeSecrets = new List<Secret>
                        {
                            new Secret("secret".Sha256())
                        }
                    },
                    StandardScopes.OfflineAccess,
                };
            scopes.AddRange(StandardScopes.All);
            return scopes;
        }
    }
}