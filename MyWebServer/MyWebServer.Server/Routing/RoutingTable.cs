using MyWebServer.Server.Common;
using MyWebServer.Server.HTTP;
using MyWebServer.Server.Responses;

namespace MyWebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method, Dictionary<string, Func<Request, Response>>> routes;

        public RoutingTable() => this.routes = new()
        {
            [Method.Get] = new(),
            [Method.Post] = new(),
            [Method.Put] = new(),
            [Method.Delete] = new(),
        };

        public IRoutingTable Map(string url, Method method, Func<Request, Response> responseFunction)
        {
            Guard.AgaintsNull(url, nameof(url));
            Guard.AgaintsNull(responseFunction, nameof(responseFunction));

            this.routes[method][url] = responseFunction;

            return this;
        }

        public IRoutingTable MapGet(string url, Func<Request, Response> responseFunction)
               => Map(url, Method.Get, responseFunction);

        public IRoutingTable MapPost(string url, Func<Request, Response> responseFunction)
               => Map(url, Method.Post, responseFunction);


        public Response MatchRequest(Request request)
        {
            var requsetMethod = request.Method;
            var requestUrl = request.Url;

            if (!this.routes.ContainsKey(requsetMethod)
                || !this.routes[requsetMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            var responseFunction = this.routes[requsetMethod][requestUrl];

            return responseFunction(request);
        }

    }
}
