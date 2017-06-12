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
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Tamkeen.IndividualsServices.WebAPIs
{
    public class Startup
    {
        IHostingEnvironment _env;
        public Startup(IHostingEnvironment env)
        {
            _env = env;

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
                if (_env.IsDevelopment() && !config.SkipSSL)
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
                .AddAuthorization(options =>
                {
                    options.AddPolicy("IdNoRequired", builder =>
                    {
                        builder.RequireAssertion(context => context.User.HasClaim(c => c.Type == "IdNo"));
                        //builder
                        //    .AddAuthenticationSchemes("Bearer")
                        //    .RequireAuthenticatedUser()
                        //    .RequireClaim("IdNo")
                        //    .Build();
                    });
                })
                .AddCors(options =>
                {
                    options.AddPolicy("CorsDefaults", builder =>
                    {
                        builder
                            .WithOrigins(config.CorsEnabledUri.ToArray())
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

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            // accept access tokens from identity server and require a scope of 'webApi'
            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                AuthenticationScheme = "Bearer",

                // this is only needed because IS3 does not include the API name in the JWT audience list
                // so we disable UseIdentityServerAuthentication JWT audience check and rely upon
                // scope validation to ensure we're only accepting tokens for the right API
                LegacyAudienceValidation = true,
                
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
