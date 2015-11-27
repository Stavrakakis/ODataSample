using System;
using System.Diagnostics;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace OData.Middleware
{
    public class LoggingFilter : ActionFilterAttribute
    {   
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var identity = actionContext.RequestContext.Principal.Identity.IsAuthenticated ? actionContext.RequestContext.Principal.Identity.Name : "Anonymous";

            var owin = actionContext.Request.GetOwinContext();

            var requestId = owin.Get<string>("custom:requestId");

            Debug.WriteLine($"{requestId} - {actionContext.Request.Method} called on {actionContext.ControllerContext.ControllerDescriptor.ControllerType} with {actionContext.Request.RequestUri} by {identity}");
        }
    }
}
