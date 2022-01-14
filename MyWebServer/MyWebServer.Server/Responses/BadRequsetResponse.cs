using MyWebServer.Server.HTTP;

namespace MyWebServer.Server.Responses
{
    public class BadRequsetResponse : Response
    {
        public BadRequsetResponse() 
            : base(StatusCode.BadRequest)
        {
        }
    }
}
