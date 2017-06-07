using Shared.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Tamkeen.IndividualsServices.Web.Framework.Mvc.Filters;
using Newtonsoft.Json.Serialization;
using FluentValidation.AspNetCore;
using Tamkeen.IndividualsServices.Web.Framework.FluentValidation;
using Tamkeen.IndividualsServices.Web.Framework.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Shared.Configuration;

namespace Tamkeen.IndividualsServices.Web.Framework.Infrastructure
{
    /// <summary>
    /// Represents object for the configuring web services and middleware on application startup
    /// </summary>
    public class WebStartup : IStartup
    {
        /// <summary>
        /// Add and configure any of the middleware
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration root of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            //add localization
            //services.AddLocalization();

            //add and configure MVC feature
            services.AddIndividualsServicesMvc();

            var config = services.BuildServiceProvider().GetService<IndividualsServicesConfig>();

        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {

        }

        public int Order => 1000;
    }
}
