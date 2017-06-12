using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tamkeen.IndividualsServices.Core.Infrastructure;
using Tamkeen.IndividualsServices.Core.Configuration;
using System.IdentityModel.Tokens.Jwt;

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

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            // accept access tokens from identity server and require a scope of 'webApi'
            application.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                AuthenticationScheme = "Bearer",

                // this is only needed because IS3 does not include the API name in the JWT audience list
                // so we disable UseIdentityServerAuthentication JWT audience check and rely upon
                // scope validation to ensure we're only accepting tokens for the right API
                LegacyAudienceValidation = true,

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
