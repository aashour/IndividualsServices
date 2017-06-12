using Microsoft.AspNet.Identity;
using System;
using System.Security.Claims;
using Tamkeen.IndividualServices.IdentityServer.AspId.Entities;
using IdSvr3 = IdentityServer3.Core;

namespace Tamkeen.IndividualServices.IdentityServer.AspId
{
    public class ClaimsFactory : ClaimsIdentityFactory<MolUser, int>
    {
        public ClaimsFactory()
        {
            this.UserIdClaimType = IdSvr3.Constants.ClaimTypes.Subject;
            this.UserNameClaimType = IdSvr3.Constants.ClaimTypes.PreferredUserName;
            this.RoleClaimType = IdSvr3.Constants.ClaimTypes.Role;
        }

        public override async System.Threading.Tasks.Task<System.Security.Claims.ClaimsIdentity> CreateAsync(UserManager<MolUser, int> manager, MolUser user, string authenticationType)
        {
            var ci = await base.CreateAsync(manager, user, authenticationType);
            if (!String.IsNullOrWhiteSpace(user.FirstName))
                ci.AddClaim(new Claim("first_name", user.FirstName));
            if (!String.IsNullOrWhiteSpace(user.SecondName))
                ci.AddClaim(new Claim("second_name", user.SecondName));
            if (!String.IsNullOrWhiteSpace(user.ThirdName))
                ci.AddClaim(new Claim("third_name", user.ThirdName));
            if (!String.IsNullOrWhiteSpace(user.FourthName))
                ci.AddClaim(new Claim("last_name", user.FourthName));
            if (user.Nationality.HasValue)
                ci.AddClaim(new Claim("nationality", user.Nationality.Value.ToString()));
            if (user.BirthDate.HasValue)
                ci.AddClaim(new Claim("birth_date", user.BirthDate.Value.ToString(), ClaimValueTypes.DateTime));
            if (user.UserTypeId.HasValue)
                ci.AddClaim(new Claim("user_type_id", user.UserTypeId.Value.ToString()));
            if (user.IdNumber.HasValue)
                ci.AddClaim(new Claim("id_number", user.IdNumber.Value.ToString()));
            if (user.IdExpiryDate.HasValue)
                ci.AddClaim(new Claim("id_expiry_date", user.IdExpiryDate.Value.ToString(), ClaimValueTypes.DateTime));
            if (user.IqamaNumber.HasValue)
                ci.AddClaim(new Claim("id_number", user.IqamaNumber.Value.ToString()));
            if (user.IqamaExpiryDate.HasValue)
                ci.AddClaim(new Claim("iqama_expiry_date", user.IqamaExpiryDate.Value.ToString(), ClaimValueTypes.DateTime));

            return ci;
        }
    }
}