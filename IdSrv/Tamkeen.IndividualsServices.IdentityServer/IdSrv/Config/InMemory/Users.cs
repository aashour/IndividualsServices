using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;
using System.Collections.Generic;
using System.Security.Claims;

namespace Tamkeen.IndividualServices.IdentityServer.IdSrv.Config.InMemory
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Username = "user1",
                    Password = "123456",
                    Subject = "user 1",

                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.Name, "first name"),
                        new Claim(Constants.ClaimTypes.FamilyName, "family"),
                        new Claim(Constants.ClaimTypes.Role, "Role1"),
                        new Claim(Constants.ClaimTypes.Email, "email@email.com"),
                        new Claim("id_number", "2157433257"),
                        new Claim("birth_date", "01/10/1984 01:12:00 AM"),
                    }
                },
                 new InMemoryUser
                {
                    Username = "user2",
                    Password = "123456",
                    Subject = "user 2",

                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.Name, "first name"),
                        new Claim(Constants.ClaimTypes.FamilyName, "family"),
                        new Claim(Constants.ClaimTypes.Role, "role2"),
                        new Claim(Constants.ClaimTypes.Email, "email@email.com"),
                        new Claim("id_number", "223377500"),
                        new Claim("birth_date", "01/10/1984 01:12:00 AM"),
                    }
                },
                  new InMemoryUser
                {
                    Username = "user3",
                    Password = "123456",
                    Subject = "user 3",

                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.Name, "first name"),
                        new Claim(Constants.ClaimTypes.FamilyName, "family"),
                        new Claim(Constants.ClaimTypes.Role, "role3"),
                        new Claim(Constants.ClaimTypes.Email, "email@email.com"),
                        new Claim("id_number", "22337744"),
                        new Claim("birth_date", "01/10/1984 01:12:00 AM"),
                    }
                }

            };
        }
    }
}