using MyWebServer.Server.HTTP;
using MyWebServer.Server.Routing;

namespace MyWebServer.Demo.Controllers
{
    public static class RoutingTableExtensions
    {
        public static IRoutingTable MapGet<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, Response> responseFunction)
            where TController : Controller 
            => routingTable.MapGet(path, request => responseFunction(
                CreateController<TController>(request)));

        public static IRoutingTable MapPost<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, Response> responseFunction)
            where TController : Controller 
            => routingTable.MapPost(path, request => responseFunction(
                CreateController<TController>(request)));

        private static TController CreateController<TController>(Request request)
         => (TController)Activator.CreateInstance(typeof(TController), new[] { request });
    }
}
