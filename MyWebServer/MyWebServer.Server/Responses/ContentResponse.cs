using MyWebServer.Server.Common;
using MyWebServer.Server.HTTP;
using System.Text;

namespace MyWebServer.Server.Responses
{
    public class ContentResponse : Response
    {
        public ContentResponse(string content, string contentType,Action<Request,Response> preRenderAction = null) 
            : base(StatusCode.OK)
        {
            Guard.AgaintsNull(content);
            Guard.AgaintsNull(contentType);

            this.PreRenderAction = preRenderAction;

            this.Headers.Add(Header.ContentType, contentType);

            this.Body = content;
        }

        public override string ToString()
        {
            if (this.Body != null)
            {
                var contentLength = Encoding.UTF8.GetByteCount(this.Body).ToString();
                this.Headers.Add(Header.ContentLength, contentLength);
            }

            return base.ToString();
        }
    }
}
