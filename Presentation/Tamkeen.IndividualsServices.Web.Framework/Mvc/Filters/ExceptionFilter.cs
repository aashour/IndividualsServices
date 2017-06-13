using System;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Tamkeen.IndividualsServices.Web.Framework.Mvc.Filters
{
    /// <summary>
    /// Represents a filter that runs after an action has thrown an exception
    /// </summary>
    public class ExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// Called after an action has thrown an exception
        /// </summary>
        /// <param name="context">Exception context</param>
        public void OnException(ExceptionContext context)
        {
            if (context == null || context.Exception == null)
                return;

            //just log an exception here, handle it later
            context.ExceptionHandled = false;

            if (context.Exception == null) return;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new JsonResult(
                new
                {
                    context.Exception.Message,
                    context.Exception.StackTrace
                });

            //try
            //{
            //    //get logger
            //    var logger = EngineContext.Current.Resolve<ILogger>();

            //    //get current customer
            //    var currentCustomer = EngineContext.Current.Resolve<IWorkContext>().CurrentCustomer;

            //    //log exception
            //    logger.Error(context.Exception.Message, context.Exception, currentCustomer);
            //}
            //catch (Exception)
            //{
            //    //don't throw new exception if occurs
            //}
        }
    }
}
