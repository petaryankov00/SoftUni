using System.Web;

namespace MyWebServer.Server.HTTP
{
    public class Request
    {
        private static Dictionary<string, Session> sessions = new();

        public Method Method { get; private set; }

        public string Url { get; private set; }

        public HeaderCollection Headers { get; private set; }

        public CookieCollection Cookies { get; private set; }   

        public Session Session { get; private set; }   

        public string Body { get; private set; }

        public IReadOnlyDictionary<string,string> Form { get; private set; }

        public static Request Parse(string requset)
        {
            var lines = requset.Split("\r\n");

            var firstLine = lines.First().Split(" ");

            Method method = ParseMethod(firstLine[0]);
            var url = firstLine[1];

            HeaderCollection headers = ParseHeaders(lines.Skip(1));
            CookieCollection cookies = ParseCookies(headers);
            Session session = GetSession(cookies);

            var bodyLines = lines.Skip(headers.Count + 2);
            var body = string.Join("\r\n", bodyLines).Trim('\0');
            var form = ParseForm(headers, body);

            return new Request
            {
                Method = method,
                Url = url,
                Headers = headers,
                Cookies = cookies,
                Session = session,
                Body = body,
                Form = form
            };
        }

        private static Session GetSession(CookieCollection cookies)
        {
            var sessionId = cookies.Contains(Session.SessionCookieName)
                ? cookies[Session.SessionCookieName]
                : Guid.NewGuid().ToString();

            if (!sessions.ContainsKey(sessionId))
            {
                sessions[sessionId] = new Session(sessionId);
            }

            return sessions[sessionId];
        }

        private static CookieCollection ParseCookies(HeaderCollection headers)
        {
            var cookieCollection = new CookieCollection();

            if (headers.Contains(Header.Cookie))
            {
                var cookieHeader = headers[Header.Cookie];

                var allCookies = cookieHeader.Split(";");

                foreach (var cookie in allCookies)
                {
                    var cookieParts = cookie.Split("=");

                    var cookieName = cookieParts[0].Trim();
                    var cookieValue = cookieParts[1].Trim();

                    cookieCollection.Add(cookieName, cookieValue);
                }
            }

            return cookieCollection;
        }

        private static Dictionary<string,string> ParseForm(HeaderCollection headers, string body)
        {
            var formCollection = new Dictionary<string,string>();

            if (headers.Contains(Header.ContentType) && headers[Header.ContentType] == ContentType.FormUrlEncoded)
            {
                var parsedResult = ParseFormData(body);

                foreach (var (name,value) in parsedResult)
                {
                    formCollection.Add(name, value);
                }
            }

            return formCollection;
        }

        private static Dictionary<string, string> ParseFormData(string body)
        => HttpUtility.UrlDecode(body)
            .Split('&')
            .Select(part => part.Split('='))
            .Where(part => part.Length == 2)
            .ToDictionary(
            part => part[0],
            part => part[1],
            StringComparer.InvariantCultureIgnoreCase);
            


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
