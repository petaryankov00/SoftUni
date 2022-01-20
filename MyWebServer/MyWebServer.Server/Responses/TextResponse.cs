using MyWebServer.Server.HTTP;

namespace MyWebServer.Server.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string content) 
            : base(content, ContentType.PlainText)
        {
        }
    }
}
