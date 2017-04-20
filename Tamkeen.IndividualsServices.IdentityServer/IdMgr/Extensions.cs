using IdentityManager;
using IdentityManager.Configuration;
using Tamkeen.IndividualServices.IdentityServer.AspId;
using Tamkeen.IndividualServices.IdentityServer.AspId.Manager;
using Tamkeen.IndividualServices.IdentityServer.AspId.Store;

namespace Tamkeen.IndividualServices.IdentityServer.IdMgr
{
    public static class Extensions
    {
        public static void ConfigureMolIdentityManagerService(this IdentityManagerServiceFactory factory, string connectionString)
        {
            factory.Register(new Registration<MolContext>(resolver => new MolContext(connectionString)));
            factory.Register(new Registration<MolUserStore>());
            factory.Register(new Registration<MolRoleStore>());
            factory.Register(new Registration<MolUserManager>());
            factory.Register(new Registration<MolRoleManager>());
            factory.IdentityManagerService = new Registration<IIdentityManagerService, MolIdentityManagerService>();
        }
    }
}