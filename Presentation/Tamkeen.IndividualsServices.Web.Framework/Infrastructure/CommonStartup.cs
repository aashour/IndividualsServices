﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tamkeen.IndividualsServices.Core.Infrastructure;
using Tamkeen.IndividualsServices.Core.Configuration;
using Tamkeen.IndividualsServices.Web.Framework.Infrastructure.Extensions;

namespace Tamkeen.IndividualsServices.Web.Framework.Infrastructure
{
    public class CommonStartup : IStartup
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration root of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            //add options feature
            services.AddOptions();

            //add isConfig configuration parameters
            var isConfig = services.ConfigureStartupConfig<IndividualsServicesConfig>(configuration.GetSection("IndividualsServices"));

            services.AddDistributedMemoryCache();
            //add memory cache
            services.AddMemoryCache();

            //add accessor to HttpContext
            services.AddHttpContextAccessor();
        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {
            //application.UseStaticFiles();
        }

        public int Order => 100;

    }
}
