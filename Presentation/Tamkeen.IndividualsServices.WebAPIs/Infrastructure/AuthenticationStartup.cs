using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tamkeen.IndividualsServices.Core.Infrastructure;
using Tamkeen.IndividualsServices.Core.Configuration;

namespace Tamkeen.IndividualsServices.WebAPIs.Infrastructure
{
    public class AuthenticationStartup : IStartup
    {

        public void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {

        }

        public void Configure(IApplicationBuilder application)
        {
            var config = application.ApplicationServices.GetService<IndividualsServicesConfig>();

            application.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                AuthenticationScheme = "Bearer",
                Authority = config.IdSrv.BaseUrl.ToString(),
                ApiName = config.IdSrv.ApiName,
                RequireHttpsMetadata = true,
                AllowedScopes = config.RequiredScopes,
                ApiSecret = config.ClientSecret
            });
        }

        public int Order => 500;

    }
}
