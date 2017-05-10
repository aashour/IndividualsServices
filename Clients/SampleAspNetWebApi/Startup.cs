using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;
using System.IdentityModel.Tokens;
using Serilog;
using IdentityManager.Core.Logging;
using IdentityManager.Logging;
using System.Web.Http;
using System.Web.Http.Cors;
using Shared.Data;
using Autofac;
using Shared.Infrastructure.DependencyManagement;
using Shared.Infrastructure;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web.Mvc;
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
                Authority = Shared.Constants.BaseAddress,
                ValidationMode = ValidationMode.ValidationEndpoint,

                RequiredScopes = new[] { "webApi" },
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


            var container = RegisterDependencies(config);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);

        }




        protected virtual IContainer RegisterDependencies(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            //dependencies
            var typeFinder = new WebAppTypeFinder();
            builder = new ContainerBuilder();
            builder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();


            //register dependencies provided by other assemblies
            builder = new ContainerBuilder();
            var drTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
            var drInstances = new List<IDependencyRegistrar>();
            foreach (var drType in drTypes)
                drInstances.Add((IDependencyRegistrar)Activator.CreateInstance(drType));
            //sort
            drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();
            foreach (var dependencyRegistrar in drInstances)
                dependencyRegistrar.Register(builder, typeFinder);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }
    }
}