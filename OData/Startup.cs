using OData.Middleware;
using OData.Models;
using Owin;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Tracing;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Routing;
using System.Web.OData.Routing.Conventions;

namespace OData
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Person>("Person");

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "odata",
                model: builder.GetEdmModel());

            //SystemDiagnosticsTraceWriter traceWriter = config.EnableSystemDiagnosticsTracing();
            //traceWriter.IsVerbose = true;
            //traceWriter.MinimumLevel = TraceLevel.Debug;

            app.Use<RequestIdMiddleware>();
            app.Use<RequestTimingMiddleware>();

            app.UseWebApi(config);
        }
    }
}
