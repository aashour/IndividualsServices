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
using Tamkeen.IndividualsServices.Core.Configuration;

namespace Tamkeen.IndividualsServices.WebAPIs
{
    public class Startup
    {
        IHostingEnvironment _env;
        public IConfigurationRoot Configuration { get; }

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

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<MvcOptions>(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                            .AddAuthenticationSchemes("Bearer")
                            .RequireAuthenticatedUser()
                            .RequireClaim("id_number")
                            .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            var serviceProvider = services.ConfigureApplicationServices(Configuration);
            var config = serviceProvider.GetService<IndividualsServicesConfig>();

            services.Configure<MvcOptions>(options =>
            {
                if (_env.IsDevelopment() && !config.SkipSSL)
                {
                    options.Filters.Add(new RequireHttpsAttribute());
                }
            });



            return serviceProvider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);
            app.UseStatusCodePages();
            app.UseCors("CorsDefaults");
            app.ConfigureRequestPipeline();


        }
    }

}
