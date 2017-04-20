using IdentityManager.Configuration;
using IdentityManager.Core.Logging;
using IdentityManager.Logging;
using IdentityServer3.Core.Configuration;
using Owin;
using Serilog;
using Tamkeen.IndividualServices.IdentityServer.IdMgr;
using Tamkeen.IndividualServices.IdentityServer.IdSrv;
using Tamkeen.IndividualServices.IdentityServer.IdSrv.Config;

namespace Tamkeen.IndividualServices.IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            LogProvider.SetCurrentLogProvider(new DiagnosticsTraceLogProvider());
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Trace()
               .CreateLogger();


            app.Map("/admin", adminApp =>
            {
                var factory = new IdentityManagerServiceFactory();
                factory.ConfigureMolIdentityManagerService("AspId");

                adminApp.UseIdentityManager(new IdentityManagerOptions()
                {
                    Factory = factory
                });
            });

            app.Map("", core =>
            {
                var idSvrFactory = Factory.Configure("IdSvr3Config");
                idSvrFactory.ConfigureUserService("AspId");

                var options = new IdentityServerOptions
                {
                    SiteName = "IdentityServer3 - Individual services AspNetIdentity",
                    SigningCertificate = Certificate.Get(),
                    Factory = idSvrFactory,
                    //AuthenticationOptions = new AuthenticationOptions
                    //{
                    //    IdentityProviders = ConfigureAdditionalIdentityProviders,
                    //}
                };

                core.UseIdentityServer(options);
            });
        }
    }
}