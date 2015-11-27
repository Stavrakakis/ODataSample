using System.Linq;
using System.Net.Http;
using System.Web.OData.Routing;
using System.Web.OData.Routing.Conventions;


namespace OData
{
    public class CustomControllerRoutingConvention : IODataRoutingConvention
    {
        public string SelectAction(ODataPath odataPath, System.Web.Http.Controllers.HttpControllerContext controllerContext, ILookup<string, System.Web.Http.Controllers.HttpActionDescriptor> actionMap)
        {
            return null;
        }

        public string SelectController(ODataPath odataPath, HttpRequestMessage request)
        {
            return "Person";
        }
    }
}
