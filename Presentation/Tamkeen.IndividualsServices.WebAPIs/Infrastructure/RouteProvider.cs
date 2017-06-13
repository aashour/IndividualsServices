using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Tamkeen.IndividualsServices.Web.Framework.Mvc.Routing;

namespace Tamkeen.IndividualsServices.WebAPIs.Infrastructure
{
    /// <summary>
    /// Represents provider that provided basic routes
    /// </summary>
    public partial class RouteProvider : IRouteProvider
    {
        public int Priority => 0;

        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="routeBuilder">Route builder</param>
        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            //page not found
            routeBuilder.MapRoute("PageNotFound", "page-not-found",
                new { controller = "Base", action = "PageNotFound" });

            routeBuilder.MapRoute("UnAuthorized", "unauthorized",
                new { controller = "Base", action = "Unauthorized" });
        }
    }
}
