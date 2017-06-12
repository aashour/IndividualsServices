using Tamkeen.IndividualsServices.Core.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Tamkeen.IndividualsServices.Web.Framework.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;

namespace Tamkeen.IndividualsServices.Web.Framework.Infrastructure
{
    /// <summary>
    /// Represents object for the configuring web services and middleware on application startup
    /// </summary>
    public class MvcStartup : IStartup
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

        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public void Configure(IApplicationBuilder application)
        {
            application.UseIndividualsServicesMvc();
        }

        public int Order => 1000;
    }
}
