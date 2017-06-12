using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Tamkeen.IndividualsServices.Core.Infrastructure;
using System;
using Tamkeen.IndividualsServices.Web.Framework.FluentValidation;
using Tamkeen.IndividualsServices.Web.Framework.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace Tamkeen.IndividualsServices.Web.Framework.Infrastructure.Extensions
{
    /// <summary>
    /// Represents extensions of IServiceCollection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services to the application and configure service provider
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration root of the application</param>
        /// <returns></returns>
        public static IServiceProvider ConfigureApplicationServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            //create, initialize and configure the engine
            var engine = EngineContext.Create();
            engine.Initialize(services);
            var serviceProvider = engine.ConfigureServices(services, configuration);

            return serviceProvider;
        }


        /// <summary>
        /// Create, bind and register as service the specified configuration parameters 
        /// </summary>
        /// <typeparam name="TConfig">Configuration parameters</typeparam>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Set of key/value application configuration properties</param>
        /// <returns>Instance of configuration parameters</returns>
        public static TConfig ConfigureStartupConfig<TConfig>(this IServiceCollection services, IConfiguration configuration) where TConfig : class, new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            //create instance of configuration
            var config = new TConfig();

            //bind it to the appropriate section of configuration
            configuration.Bind(config);

            //and register it as a service
            services.AddSingleton(config);

            return config;
        }

        /// <summary>
        /// Register HttpContextAccessor
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        /// <summary>
        /// Add and configure MVC for the application
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <returns>A builder for configuring MVC services</returns>
        public static IMvcBuilder AddIndividualsServicesMvc(this IServiceCollection services)
        {
            //add basic MVC feature
            var mvcBuilder = services.AddMvc()
                //MVC now serializes JSON with camel case names by default
                //Use this code to avoid camel case names by default
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver()); ;

            //add global exception filter
            mvcBuilder.AddMvcOptions(options => options.Filters.Add(new ExceptionFilter()));
            //mvcBuilder.AddMvcOptions(options => options.Filters.Add(new AuthorizationFillter()));

            //add fluent validation
            mvcBuilder.AddFluentValidation(configuration => configuration.ValidatorFactoryType = typeof(ValidatorFactory));

            return mvcBuilder;
        }
    }
}
