using System;
using IdentityManager.Configuration;
using IdentityManager.Core.Logging;
using IdentityManager.Logging;
using IdentityServer3.Core.Configuration;
using Owin;
using Serilog;
using Tamkeen.IndividualServices.IdentityServer.IdMgr;
using Tamkeen.IndividualServices.IdentityServer.IdSrv;
using Tamkeen.IndividualServices.IdentityServer.IdSrv.Config;
using Tamkeen.IndividualServices.IdentityServer.IdSrv.Config.InMemory;
using IdentityServer3.Host.Config;
using Microsoft.Owin.Security.Google;

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
#if DEBUG
            ConfigureIdentityInMemory(app);
#else
            ConfigureIdentityWithConfigurationDB(app);
#endif


        }
        private void ConfigureIdentityInMemory(IAppBuilder app)
        {

            //app.Map("/admin", adminApp =>
            //{
            //    var factory = new IdentityManagerServiceFactory();
            //    factory.ConfigureMolIdentityManagerService();

            //    adminApp.UseIdentityManager(new IdentityManagerOptions()
            //    {
            //        Factory = factory
            //    });
            //});

            app.Map("/core", idsrvApp =>
            {
                idsrvApp.UseIdentityServer(new IdentityServerOptions
                {
                    SiteName = "IdentityServer3 - Individual services AspNetIdentity(in memory)",
                    RequireSsl = true,
                    SigningCertificate = Certificate.Get(),

                    Factory = new IdentityServerServiceFactory()
                                .UseInMemoryUsers(Users.Get())
                                .UseInMemoryClients(Clients.Get(false))
                                .UseInMemoryScopes(Scopes.Get()),

                    AuthenticationOptions = new IdentityServer3.Core.Configuration.AuthenticationOptions
                    {
                        EnablePostSignOutAutoRedirect = true,
                        //IdentityProviders = ConfigureIdentityProviders
                    }
                });
            });
        }

        private void ConfigureIdentityProviders(IAppBuilder app, string signInAsType)
        {
            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
            {
                AuthenticationType = "Google",
                Caption = "Sign-in with Google",
                SignInAsAuthenticationType = signInAsType,

                ClientId = "701386055558-9epl93fgsjfmdn14frqvaq2r9i44qgaa.apps.googleusercontent.com",
                ClientSecret = "3pyawKDWaXwsPuRDL7LtKm_o"
            });
        }

        private void ConfigureIdentityWithConfigurationDB(IAppBuilder app)
        {
            app.Map("/admin", adminApp =>
            {
                var factory = new IdentityManagerServiceFactory();
                factory.ConfigureMolIdentityManagerService("AspId");

                adminApp.UseIdentityManager(new IdentityManagerOptions()
                {
                    Factory = factory
                });
            });

            app.Map("/core", core =>
            {
                var idSvrFactory = Factory.Configure("IdSvr3Config", "dbo");
                idSvrFactory.ConfigureUserService("AspId");

                var options = new IdentityServerOptions
                {
                    SiteName = "IdentityServer3 - Individual services AspNetIdentity",
                    RequireSsl = true,
                    SigningCertificate = Certificate.Get(),

                    Factory = idSvrFactory,
                    //AuthenticationOptions = new AuthenticationOptions
                    //{
                    //    IdentityProviders = ConfigureAdditionalIdentityProviders,
                    //},

                    EventsOptions = new EventsOptions
                    {
                        RaiseSuccessEvents = true,
                        RaiseErrorEvents = true,
                        RaiseFailureEvents = true,
                        RaiseInformationEvents = true
                    }
                };

                core.UseIdentityServer(options);
            });
        }
    }
}