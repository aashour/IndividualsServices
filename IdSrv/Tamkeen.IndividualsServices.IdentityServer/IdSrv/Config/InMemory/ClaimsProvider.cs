using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.Default;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Validation;
using System.Security.Claims;

namespace Tamkeen.IndividualServices.IdentityServer.IdSrv.Config.InMemory
{
    public class ClaimsProvider : DefaultClaimsProvider
    {
        public ClaimsProvider(IUserService users) : base(users)
        {
        }


        public override Task<IEnumerable<Claim>> GetAccessTokenClaimsAsync(ClaimsPrincipal subject, Client client, IEnumerable<Scope> scopes, ValidatedRequest request)
        {
            var baseclaims = base.GetAccessTokenClaimsAsync(subject, client, scopes, request);

            var claims = new List<Claim>();
            if (subject.Identity.Name == "user 1")
            {
                claims.Add(new Claim("role", "super_user"));
                claims.Add(new Claim("role", "asset_manager"));
            }

            claims.AddRange(baseclaims.Result);

            return Task.FromResult(claims.AsEnumerable());
        }

        public override Task<IEnumerable<Claim>> GetIdentityTokenClaimsAsync(ClaimsPrincipal subject, Client client, IEnumerable<Scope> scopes, bool includeAllIdentityClaims, ValidatedRequest request)
        {
            var rst = base.GetIdentityTokenClaimsAsync(subject, client, scopes, includeAllIdentityClaims, request);
            return rst;
        }

    }
}