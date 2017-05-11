using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IdentityServer3.Core;
using IdentityServer3.Core.Extensions;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.Default;

namespace Tamkeen.IndividualServices.IdentityServer.IdSrv.Config.InMemory
{
    public class UserService : UserServiceBase
    {
        public class CustomUser
        {
            public int Id { get; set; }
            public string Subject { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public List<Claim> Claims { get; set; }
        }

        public static List<CustomUser> Users = new List<CustomUser>()
        {
            new CustomUser{
                Id=1,
                Username = "user1",
                Password = "123456",
                Subject = "user 1",
                Claims = new List<Claim>{
                    new Claim(Constants.ClaimTypes.GivenName, "first name"),
                    new Claim(Constants.ClaimTypes.FamilyName, "family"),
                    new Claim(Constants.ClaimTypes.Role, "Role1"),
                    new Claim(Constants.ClaimTypes.Email, "email@email.com"),
                    new Claim("iqama_number", "2157433257"),
                    new Claim("birth_date", "01/10/1984 01:12:00 AM"),
                }
            },
            new CustomUser{
                Id=2,
                Username = "user2",
                Password = "123456",
                Subject = "user 2",
                Claims = new List<Claim>{
                    new Claim(Constants.ClaimTypes.GivenName, "first name"),
                    new Claim(Constants.ClaimTypes.FamilyName, "family"),
                    new Claim(Constants.ClaimTypes.Role, "role2"),
                    new Claim(Constants.ClaimTypes.Email, "email@email.com"),
                    new Claim("iqama_number", "223377500"),
                    new Claim("birth_date", "01/10/1984 01:12:00 AM"),
                }
            },
            new CustomUser{
                Id=3,
                Username = "user3",
                Password = "123456",
                Subject = "user 3",
                Claims = new List<Claim>{
                    new Claim(Constants.ClaimTypes.GivenName, "first name"),
                    new Claim(Constants.ClaimTypes.FamilyName, "family"),
                    new Claim(Constants.ClaimTypes.Role, "role3"),
                    new Claim(Constants.ClaimTypes.Email, "email@email.com"),
                    new Claim("iqama_number", "22337744"),
                    new Claim("birth_date", "01/10/1984 01:12:00 AM"),
                }
            },
        };

        //public override Task GetProfileDataAsync(ProfileDataRequestContext context)
        //{
        //    var identity = new ClaimsIdentity();
        //    CustomUser user = null;

        //    // issue the claims for the user
        //    user = Users.SingleOrDefault(x => x.Subject == context.Subject.GetSubjectId());
        //    if (!string.IsNullOrEmpty(context.Subject.Identity.Name))
        //    {
        //        context.IssuedClaims = user.Claims.Where(x => context.RequestedClaimTypes.Contains(x.Type));
        //    }

        //    return Task.FromResult(0);
        //}
        public override Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var identity = new ClaimsIdentity();
            CustomUser user = null;

            if (!string.IsNullOrEmpty(context.Subject.Identity.Name))
                user = Users.SingleOrDefault(x => x.Subject == context.Subject.GetSubjectId());
            else
            {
                // get the sub claim
                var claim = context.Subject.FindFirst(item => item.Type == "sub");
                if (claim != null)
                {
                    //int userId = int.Parse(claim.Value);
                    user = Users.SingleOrDefault(x => x.Subject == claim.Value);
                }
            }

            if (user != null)
            {
                identity.AddClaims(user.Claims.ToArray());
            }

            context.IssuedClaims = identity.Claims;
            return Task.FromResult(identity.Claims);
        }

        public override Task AuthenticateLocalAsync(LocalAuthenticationContext context)
        {
            var user = Users.SingleOrDefault(x => x.Username == context.UserName && x.Password == context.Password);
            if (user != null)
            {
                context.AuthenticateResult = new AuthenticateResult(user.Subject, user.Username);
            }

            return Task.FromResult(0);
        }
    }
}
