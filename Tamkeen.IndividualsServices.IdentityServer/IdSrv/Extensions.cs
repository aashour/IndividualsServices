using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using Tamkeen.IndividualServices.IdentityServer.AspId;
using Tamkeen.IndividualServices.IdentityServer.AspId.Manager;
using Tamkeen.IndividualServices.IdentityServer.AspId.Store;

namespace Tamkeen.IndividualServices.IdentityServer.IdSrv
{
    public static class Extensions
    {
        public static void ConfigureUserService(this IdentityServerServiceFactory factory, string connString)
        {
            factory.UserService = new Registration<IUserService, MolUserService>();
            factory.Register(new Registration<MolUserManager>());
            factory.Register(new Registration<MolUserStore>());
            factory.Register(new Registration<MolContext>(resolver => new MolContext(connString)));
        }
    }
}