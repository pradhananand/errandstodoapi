using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ErrandsTodoApi.Filters
{

    /// <summary>
    /// Filter attribute to capture api exceptions
    /// </summary>
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// onexception method to capture all exceptions in the api
        /// </summary>
        /// <param name="context"><see cref="ExceptionContext"/></param>
        public override void OnException(ExceptionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context is null");
            }
            if (context.Exception != null)
            {
                if (context.Exception is ArgumentNullException ||
                    context.Exception is ArgumentException)
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                }
                context.Result = new JsonResult(context.Exception.Message);
            }
        }
    }
}
