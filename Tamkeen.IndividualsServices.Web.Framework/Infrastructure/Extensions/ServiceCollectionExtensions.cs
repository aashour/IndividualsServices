using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Shared.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamkeen.IndividualsServices.Web.Framework.FluentValidation;
using Tamkeen.IndividualsServices.Web.Framework.Mvc.Filters;

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
            var builder = services.AddMvcCore();

            //create engine
            var engine = EngineContext.Create();

            //then initialize
            var hostingEnvironment = services.BuildServiceProvider().GetRequiredService<IHostingEnvironment>();
            engine.Initialize(hostingEnvironment, builder.PartManager);

            //and configure it
            var serviceProvider = engine.ConfigureServices(services, configuration);

            return serviceProvider;
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

            //add fluent validation
            mvcBuilder.AddFluentValidation(configuration => configuration.ValidatorFactoryType = typeof(ValidatorFactory));

            return mvcBuilder;
        }
    }
}
