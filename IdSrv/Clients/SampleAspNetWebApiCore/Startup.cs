using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace SampleAspNetWebApiCore
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
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MvcOptions>(options =>
            {
                var authPolicy = new AuthorizationPolicyBuilder()
                            .AddAuthenticationSchemes("Bearer")
                            .RequireAuthenticatedUser()
                            .RequireClaim("id_number")
                            .Build();
                options.Filters.Add(new AuthorizeFilter(authPolicy));

            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins("https://localhost:44300", "https://localhost:44305", "http://localhost:44305", "https://localhost:44304")
                        .WithHeaders("accept", "authorization")
                        .WithMethods("get")
                        .WithExposedHeaders("WWW-Authenticate")
                        .AllowCredentials();
                });
            });

            // Add framework services.
            services.AddMvc();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            // accept access tokens from identityserver and require a scope of 'webApi'
            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = "https://localhost:44300/core",
                RequireHttpsMetadata = false,

                ApiName = "Tamkeen.IndividualsServices.WebAPIs",
                ApiSecret = "secret",

                // this is only needed because IS3 does not include the API name in the JWT audience list
                // so we disable UseIdentityServerAuthentication JWT audience check and rely upon
                // scope validation to ensure we're only accepting tokens for the right API
                LegacyAudienceValidation = true,
                AllowedScopes = { "Tamkeen.IndividualsServices.WebAPIs" }
            });


            app.UseMvc();
            app.UseCors("CorsPolicy");
        }
    }
}
