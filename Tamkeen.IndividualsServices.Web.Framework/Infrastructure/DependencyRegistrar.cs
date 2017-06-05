using Autofac;
using Autofac.Integration.Mvc;
using Shared.Data;
using Shared.Infrastructure;
using Shared.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamkeen.IndividualsServices.Data;
using Tamkeen.IndividualsServices.Services;
using Autofac.Integration.WebApi;
using Shared.Caching;
using Autofac.Core;
using System.Reflection;
using Shared.Configuration;
using Autofac.Builder;
using Tamkeen.IndividualsServices.Services.Configuration;

namespace Tamkeen.IndividualsServices.Web.Framework.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 0;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {

            //controllers
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());
            builder.RegisterApiControllers(typeFinder.GetAssemblies().ToArray()).InstancePerRequest();

            //data layer
            var dataSettingsManager = new DataSettingsManager();
            var dataProviderSettings = dataSettingsManager.LoadSettings(connectionStringName: "mol:connectionstring");
            builder.Register(c => dataProviderSettings).As<DataSettings>();
            builder.Register(x => new EfDataProviderManager(x.Resolve<DataSettings>())).As<BaseDataProviderManager>().InstancePerDependency();

            builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerDependency();

            if (dataProviderSettings != null && dataProviderSettings.IsValid())
            {
                var efDataProviderManager = new EfDataProviderManager(dataProviderSettings);
                var dataProvider = efDataProviderManager.LoadDataProvider();
                dataProvider.InitConnectionFactory();

                builder.Register<IDbContext>(c => new IndividualsServicesObjectContext(dataProviderSettings.DataConnectionString)).InstancePerLifetimeScope();
            }
            else
            {
                builder.Register<IDbContext>(c => new IndividualsServicesObjectContext(dataProviderSettings.DataConnectionString)).InstancePerLifetimeScope();
            }

            //repositories
            builder.RegisterGeneric(typeof(EfRepository<,>)).As(typeof(IRepository<,>)).InstancePerLifetimeScope();

            //cache manager
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().SingleInstance();


            //services
            builder.RegisterType<LaborerService>().As<ILaborerService>().InstancePerLifetimeScope();
            builder.RegisterType<ServiceLogService>().As<IServiceLogService>().InstancePerLifetimeScope();

            //register all settings
            builder.RegisterSource(new SettingsSource());
        }
    }


    public class SettingsSource : IRegistrationSource
    {
        static readonly MethodInfo BuildMethod = typeof(SettingsSource).GetMethod(
            "BuildRegistration",
            BindingFlags.Static | BindingFlags.NonPublic);

        public IEnumerable<IComponentRegistration> RegistrationsFor(
                Service service,
                Func<Service, IEnumerable<IComponentRegistration>> registrations)
        {
            if (service is TypedService ts && typeof(ISettings).IsAssignableFrom(ts.ServiceType))
            {
                var buildMethod = BuildMethod.MakeGenericMethod(ts.ServiceType);
                yield return (IComponentRegistration)buildMethod.Invoke(null, null);
            }
        }

        static IComponentRegistration BuildRegistration<TSettings>() where TSettings : ISettings, new()
        {
            return RegistrationBuilder
                .ForDelegate((c, p) =>
                {
                    return c.Resolve<ISettingService>().LoadSetting<TSettings>();
                })
                .InstancePerLifetimeScope()
                .CreateRegistration();
        }

        public bool IsAdapterForIndividualComponents { get { return false; } }
    }
}
