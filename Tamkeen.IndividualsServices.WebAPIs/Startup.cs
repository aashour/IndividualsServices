using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tamkeen.IndividualsServices.Services;
using Tamkeen.IndividualsServices.Data;
using Shared.Data;
using Shared.Models;
using Microsoft.AspNetCore.StaticFilesEx;

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
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddTransient<IRepository<UserEstablishment, long>, EfRepository<UserEstablishment, long>>();
            services.AddTransient<IDbContext>(context => new IndividualsServicesObjectContext(Configuration["mol:connectionstring"]));
            services.AddTransient<IRepository<Laborer, long>, EfRepository<Laborer, long>>();
            services.AddTransient<IRepository<Establishment, long>, EfRepository<Establishment, long>>();
            services.AddTransient<IRepository<ServiceLog, int>, EfRepository<ServiceLog, int>>();

            services.AddTransient<INitaqatService, NitaqatService>();
            services.AddTransient<ILaborerService, LaborerService>();
            services.AddTransient<IEstablishmentService, EstablishmentService>();
            services.AddTransient<IRunawayService, RunawayService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();

            app.UseStaticFiles();
        }
    }

}
