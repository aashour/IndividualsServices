using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Tamkeen.IndividualServices.IdentityServer.AspId.Entities;

namespace Tamkeen.IndividualServices.IdentityServer.AspId.Store
{
    public class InMemoryMolUserStore : IUserStore<MolUser, int>, IUserPasswordStore<MolUser, int>
    {

        public Task<MolUser> FindByNameAsync(string userName)
        {
            MolUser user = InMemoryMolContext.Users.Find(item => item.UserName == userName);
            return Task.FromResult<MolUser>(user);
        }

        public Task CreateAsync(MolUser user)
        {
            return Task.FromResult<bool>(InMemoryMolContext.Add(user));
        }
        public Task<string> GetPasswordHashAsync(MolUser user)
        {
            return Task.FromResult<string>(user.PasswordHash.ToString());
        }
        public Task SetPasswordHashAsync(MolUser user, string passwordHash)
        {
            return Task.FromResult<string>(user.PasswordHash = passwordHash);
        }

        public Task DeleteAsync(MolUser user)
        {
            return Task.FromResult<bool>(InMemoryMolContext.Delete(user));
        }

        public Task<MolUser> FindByIdAsync(int userId)
        {
            return Task.FromResult<MolUser>(InMemoryMolContext.Users.Find(usr => usr.Id == userId));
        }

        public Task UpdateAsync(MolUser user)
        {
            return Task.FromResult<bool>(InMemoryMolContext.Update(user));
        }
        public Task<bool> HasPasswordAsync(MolUser user)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}