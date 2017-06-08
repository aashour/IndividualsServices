using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tamkeen.IndividualsServices.Web.Framework.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace Tamkeen.IndividualsServices.WebAPIs
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var serviceProvider = services.ConfigureApplicationServices(Configuration);
            var config = serviceProvider.GetService<Tamkeen.IndividualsServices.Core.Configuration.IndividualsServicesConfig>();

            services.Configure<MvcOptions>(options =>
            {
                if (!config.SkipSSL /*&& _hostingEnv.IsDevelopment()*/)
                {
                    options.Filters.Add(new RequireHttpsAttribute());
                }

                var policy = new AuthorizationPolicyBuilder()
                            .AddAuthenticationSchemes("Bearer")
                            .RequireAuthenticatedUser()
                            .RequireClaim("IdNo")
                            .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            services
                .AddAuthorization()
                .AddCors(options =>
                {
                    options.AddPolicy("CorsDefaults", builder =>
                    {
                        builder.WithOrigins(config.CorsEnabledUri.ToArray())
                            .WithHeaders(config.CorsEnabledHeaders.ToArray())
                            .WithMethods(config.CorsEnabledVerbs.ToArray())
                            .WithExposedHeaders(config.CorsExposedHeaders.ToArray())
                            .AllowCredentials();
                    });
                });

            return serviceProvider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);

            var config = app.ApplicationServices.GetService<Tamkeen.IndividualsServices.Core.Configuration.IndividualsServicesConfig>();


            // accept access tokens from identity server and require a scope of 'webApi'
            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                AuthenticationScheme = "Bearer",
                Authority = config.IdSrv.BaseUrl.ToString(),
                ApiName = config.IdSrv.ApiName,
                RequireHttpsMetadata = true,
                AllowedScopes = config.RequiredScopes,
                ApiSecret = config.ClientSecret
            });

            app.ConfigureRequestPipeline();
        }
    }

}
