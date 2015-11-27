using System.Threading.Tasks;
using Microsoft.Owin;
using System;
using System.Diagnostics;

namespace OData.Middleware
{
    public class RequestTimingMiddleware : OwinMiddleware
    {
        public RequestTimingMiddleware(OwinMiddleware next) : base(next)
        {

        }

        public async override Task Invoke(IOwinContext context)
        {
            var start = DateTime.Now;
            var requestId = context.Get<string>("custom:requestId");

            await this.Next.Invoke(context);

            var end = DateTime.Now;

            var duration = end - start;
            
            Debug.WriteLine($"{requestId} - {context.Request.Method} {context.Request.Uri} process in {duration.TotalMilliseconds} ms");
        }
    }
}
