using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;
using Serilog;
using IdentityManager.Core.Logging;
using IdentityManager.Logging;
using System.Web.Http;
using System.Web.Http.Cors;
using Autofac;
using System.Collections.Generic;
using System;
using System.Linq;
using Autofac.Integration.WebApi;

[assembly: OwinStartup(typeof(SampleAspNetWebApi.Startup))]
namespace SampleAspNetWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            LogProvider.SetCurrentLogProvider(new DiagnosticsTraceLogProvider());
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Verbose()
               .WriteTo.Trace()
               .CreateLogger();

            // accept access tokens from identityserver and require a scope of 'webApi'
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44300/core",
                ValidationMode = ValidationMode.ValidationEndpoint,

                RequiredScopes = new[] { "Tamkeen.IndividualsServices.WebAPIs" },
                ClientSecret = "secret"
            });

            // configure web api
            var config = new HttpConfiguration();

            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.EnableCors(
                    new EnableCorsAttribute(
                            "https://localhost:44300, https://localhost:44305, http://localhost:44305 ,https://localhost:44304",
                            "accept, authorization",
                            "GET", "WWW-Authenticate"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );



            app.UseWebApi(config);

        }


        
    }
}