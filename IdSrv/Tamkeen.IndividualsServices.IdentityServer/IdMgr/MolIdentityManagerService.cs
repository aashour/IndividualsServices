using IdentityManager.AspNetIdentity;
using Tamkeen.IndividualServices.IdentityServer.AspId.Entities;
using Tamkeen.IndividualServices.IdentityServer.AspId.Manager;

namespace Tamkeen.IndividualServices.IdentityServer.IdMgr
{
    public class MolIdentityManagerService : AspNetIdentityManagerService<MolUser, int, MolRole, int>
    {
        public MolIdentityManagerService(MolUserManager userMgr, MolRoleManager roleMgr)
            : base(userMgr, roleMgr)
        {

        }

    }
}