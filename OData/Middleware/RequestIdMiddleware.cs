using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OData.Middleware
{
    public class RequestIdMiddleware : OwinMiddleware
    {
        public RequestIdMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            context.Set("custom:requestId", Guid.NewGuid().ToString());

            await this.Next.Invoke(context);
        }
    }
}
