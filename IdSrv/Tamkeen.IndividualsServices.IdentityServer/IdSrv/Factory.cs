using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.Default;
using IdentityServer3.Host.Config;
using IdentityServer3.EntityFramework;
using IdentityServer3.Core.Models;
using System.Collections.Generic;
using System.Linq;
using IdentityServer3.Core.Services.Contrib;
using System.Net.Http.Headers;
using Microsoft.Owin;

namespace Tamkeen.IndividualServices.IdentityServer.IdSrv
{
    class Factory
    {
        public static IdentityServerServiceFactory Configure(string connString, string schema)
        {
            var efConfig = new EntityFrameworkServiceOptions
            {
                ConnectionString = connString,
                Schema = schema,
                //SynchronousReads = true
            };

            // these two calls just pre-populate the test DB from the in-memory configuration
            ConfigureClients(Clients.Get(true), efConfig);
            ConfigureScopes(Scopes.Get(), efConfig);

            var factory = new IdentityServerServiceFactory();

            factory.RegisterConfigurationServices(efConfig);
            factory.RegisterOperationalServices(efConfig);

            factory.ConfigureClientStoreCache();
            factory.ConfigureScopeStoreCache();

            factory.CorsPolicyService = new Registration<ICorsPolicyService>(new DefaultCorsPolicyService { AllowAll = true });

            var localeOpts = new LocaleOptions
            {
                LocaleProvider = env =>
                {
                    var owinContext = new OwinContext(env);
                    var owinRequest = owinContext.Request;
                    var headers = owinRequest.Headers;
                    var accept_language_header = headers["accept-language"].ToString();
                    var languages = accept_language_header
                        .Split(',')
                        .Select(StringWithQualityHeaderValue.Parse)
                        .OrderByDescending(s => s.Quality.GetValueOrDefault(1));
                    var locale = languages.First().Value;

                    return locale;
                }
            };
            factory.Register(new Registration<LocaleOptions>(localeOpts));
            factory.LocalizationService = new Registration<ILocalizationService, GlobalizedLocalizationService>();

            return factory;
        }

        public static void ConfigureClients(IEnumerable<Client> clients, EntityFrameworkServiceOptions options)
        {
            using (var db = new ClientConfigurationDbContext(options.ConnectionString, options.Schema))
            {
                if (!db.Clients.Any())
                {
                    foreach (var c in clients)
                    {
                        var e = c.ToEntity();
                        db.Clients.Add(e);
                    }
                    db.SaveChanges();
                }
            }
        }

        public static void ConfigureScopes(IEnumerable<Scope> scopes, EntityFrameworkServiceOptions options)
        {
            using (var db = new ScopeConfigurationDbContext(options.ConnectionString, options.Schema))
            {
                if (!db.Scopes.Any())
                {
                    foreach (var s in scopes)
                    {
                        var e = s.ToEntity();
                        db.Scopes.Add(e);
                    }
                    db.SaveChanges();
                }
            }
        }
    }
}