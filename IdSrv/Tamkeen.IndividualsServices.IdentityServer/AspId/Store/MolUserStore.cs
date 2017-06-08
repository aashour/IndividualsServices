using Microsoft.AspNet.Identity.EntityFramework;
using Tamkeen.IndividualServices.IdentityServer.AspId.Entities;

namespace Tamkeen.IndividualServices.IdentityServer.AspId.Store
{
    public class MolUserStore : UserStore<MolUser, MolRole, int, MolUserLogin, MolUserRole, MolUserClaim>
    {
        public MolUserStore(MolContext ctx)
            : base(ctx)
        {
        }
    }
}