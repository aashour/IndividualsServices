using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Extensions
{
    /// <summary>
    /// Represents extensions of IApplicationBuilder
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Add exception handling
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        /// <param name="useDetailedExceptionPage">Whether to use detailed exception page</param>
        public static void UseExceptionHandler(this IApplicationBuilder application, bool useDetailedExceptionPage)
        {
            if (useDetailedExceptionPage)
            {
                //get detailed exceptions for developing and testing purposes
                application.UseDeveloperExceptionPage();
            }
            else
            {
                //or use special exception handler
                application.UseExceptionHandler("/errorpage.htm");
            }
        }
    }
}
