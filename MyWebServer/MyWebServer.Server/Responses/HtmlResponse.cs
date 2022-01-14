using MyWebServer.Server.HTTP;

namespace MyWebServer.Server.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string content) 
            : base(content, ContentType.Html)
        {
            
        }
    }
}
