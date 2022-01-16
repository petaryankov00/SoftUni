using MyWebServer.Server.HTTP;

namespace MyWebServer.Server.Responses
{
    public class TextFileResponse : Response
    {
        public TextFileResponse(string fileName) 
            : base(StatusCode.OK)
        {
            this.FileName = fileName;

            this.Headers.Add(Header.ContentType, ContentType.PlainText);
        }

        public string FileName { get; init; }

        public override string ToString()
        {
            if (File.Exists(this.FileName))
            {
                this.Body = File.ReadAllTextAsync(this.FileName).Result;
                var fileBytes = new FileInfo(this.FileName).Length;

                this.Headers.Add(Header.ContentLength, fileBytes.ToString());
                this.Headers.Add(Header.ContentDisposition, $"attachment; filename=\"{this.FileName}\"");
            }

            return base.ToString();
        }
    }
}
