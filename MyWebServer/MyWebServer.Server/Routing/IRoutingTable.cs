using MyWebServer.Server.HTTP;

namespace MyWebServer.Server.Routing
{
    public interface IRoutingTable
    {
        IRoutingTable Map(string url, Method method, Func<Request,Response> responseFunction);
        IRoutingTable MapGet(string url, Func<Request, Response> responseFunction);
        IRoutingTable MapPost(string url, Func<Request, Response> responseFunction);
    }
}
