using IdentityServer3.AspNetIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tamkeen.IndividualServices.IdentityServer.AspId.Entities;
using Tamkeen.IndividualServices.IdentityServer.AspId.Manager;

namespace Tamkeen.IndividualServices.IdentityServer.IdSrv
{
    public class MolUserService : AspNetIdentityUserService<MolUser, int>
    {
        //OwinContext ctx;
        public MolUserService(MolUserManager userMgr)
            : base(userMgr)
        {
            //ctx = new OwinContext(owinEnv.Environment);
        }

        //custom login page
        //public override Task PreAuthenticateAsync(PreAuthenticationContext context)
        //{
        //    var id = ctx.Request.Query.Get("signin");
        //    context.AuthenticateResult = new AuthenticateResult("~/custom/login?id=" + id, (IEnumerable<Claim>)null);
        //    return Task.FromResult(0);
        //}


        protected override async Task<IEnumerable<System.Security.Claims.Claim>> GetClaimsFromAccount(MolUser user)
        {
            var claims = (await base.GetClaimsFromAccount(user)).ToList();


            if (!String.IsNullOrWhiteSpace(user.FirstName))
                claims.Add(new Claim("first_name", user.FirstName));
            if (!String.IsNullOrWhiteSpace(user.SecondName))
                claims.Add(new Claim("second_name", user.SecondName));
            if (!String.IsNullOrWhiteSpace(user.ThirdName))
                claims.Add(new Claim("third_name", user.ThirdName));
            if (!String.IsNullOrWhiteSpace(user.FourthName))
                claims.Add(new Claim("last_name", user.FourthName));
            if (user.Nationality.HasValue)
                claims.Add(new Claim("nationality", user.Nationality.Value.ToString()));
            if (user.BirthDate.HasValue)
                claims.Add(new Claim("birth_date", user.BirthDate.Value.ToString(), ClaimValueTypes.DateTime));
            if (user.UserTypeId.HasValue)
                claims.Add(new Claim("user_type_id", user.UserTypeId.Value.ToString()));
            if (user.IdNumber.HasValue)
                claims.Add(new Claim("id_number", user.IdNumber.Value.ToString()));
            if (user.IdExpiryDate.HasValue)
                claims.Add(new Claim("id_expiry_date", user.IdExpiryDate.Value.ToString(), ClaimValueTypes.DateTime));
            if (user.IqamaNumber.HasValue)
                claims.Add(new Claim("id_number", user.IqamaNumber.Value.ToString()));
            if (user.IqamaExpiryDate.HasValue)
                claims.Add(new Claim("iqama_expiry_date", user.IqamaExpiryDate.Value.ToString(), ClaimValueTypes.DateTime));


            return claims;
        }
    }
}
