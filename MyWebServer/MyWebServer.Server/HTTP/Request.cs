using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server.HTTP
{
    public class Request
    {
        public Method Method { get; private set; }

        public string Url { get; private set; }

        public HeaderCollection Headers { get; private set; }

        public string Body { get; private set; }

        public static Request Parse(string requset)
        {
            var lines = requset.Split("\r\n");

            var firstLine = lines.First().Split(" ");

            Method method = ParseMethod(firstLine[0]);
            var url = firstLine[1];

            HeaderCollection headers = ParseHeaders(lines.Skip(1));

            var bodyLines = lines.Skip(headers.Count + 2);
            var body = string.Join("\r\n", bodyLines);


            return new Request
            {
                Method = method,
                Url = url,
                Headers = headers,
                Body = body,
            };
        }

        private static HeaderCollection ParseHeaders(IEnumerable<string> headerLines)
        {
            var headersToReturn = new HeaderCollection();

            foreach (var currHeaderLine in headerLines)
            {
                if (currHeaderLine == string.Empty)
                {
                    break;
                }

                var headerParts = currHeaderLine.Split(":", 2);

                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Invalid Header!");
                }

                var headerName = headerParts[0];
                var headerValue = headerParts[1].Trim();   
                headersToReturn.Add(headerName, headerValue);
            }

            return headersToReturn;
            
        }

        private static Method ParseMethod(string method)
        {
            try
            {
                return Enum.Parse<Method>(method,true);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Method {method} is not supported!");
            }
        }
    }

}
