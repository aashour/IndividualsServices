using Microsoft.AspNet.Identity;
using Tamkeen.IndividualServices.IdentityServer.AspId.Entities;
using Tamkeen.IndividualServices.IdentityServer.AspId.Store;

namespace Tamkeen.IndividualServices.IdentityServer.AspId.Manager
{
    public class MolRoleManager : RoleManager<MolRole, int>
    {
        public MolRoleManager(MolRoleStore store)
            : base(store)
        {
        }
    }
}