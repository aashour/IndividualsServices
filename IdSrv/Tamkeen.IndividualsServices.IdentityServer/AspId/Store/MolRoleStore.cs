using Microsoft.AspNet.Identity.EntityFramework;
using Tamkeen.IndividualServices.IdentityServer.AspId.Entities;

namespace Tamkeen.IndividualServices.IdentityServer.AspId.Store
{
    public class MolRoleStore : RoleStore<MolRole, int, MolUserRole>
    {
        public MolRoleStore(MolContext ctx)
            : base(ctx)
        {
        }
    }
}