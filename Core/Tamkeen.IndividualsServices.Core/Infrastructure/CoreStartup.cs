using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tamkeen.IndividualsServices.Core.Configuration;
using Tamkeen.IndividualsServices.Core.Extensions;

namespace Tamkeen.IndividualsServices.Core.Infrastructure
{
    /// <summary>
    /// Represents object for the configuring core services and middleware on application startup
    /// </summary>
    public class CoreStartup : IStartup
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
            //exception handling
            var hostingEnvironment = EngineContext.Current.Resolve<IHostingEnvironment>();
            application.UseExceptionHandler(hostingEnvironment.IsDevelopment());
        }

        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order
        {
            //load core services first
            get { return 0; }
        }
    }
}
