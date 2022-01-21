using MyWebServer.Demo.Models;
using MyWebServer.Server.HTTP;
using System.IO;
using System.Text;
using System.Web;

namespace MyWebServer.Demo.Controllers
{
    public class HomeController : Controller
    {
        private const string FileName = "content.txt";

        public HomeController(Request request)
            : base(request)
        {
        }

        public Response Index() => Text("Hello from the server");

        public Response Redirect() => Redirect("https://softuni.org/");

        public Response Html() => View();

        public Response HtmlFormPost()
        {
            var name = this.Request.Form["Name"];
            var age = this.Request.Form["Age"];

            var model = new FormViewModel
            {
                Name = name,
                Age = age
            };

            return View(model);
        }

        public Response Content() => View();

        public Response DownloadContent()
        {
            DownloadSitesAsText(FileName, new string[] { "https://softuni.org/", "https://wikipedia.bg/" })
                .Wait();

            return File(FileName);
        }

        public Response Cookies()
        {
            var requesHasCookies = this.Request.Cookies
                   .Any(c => c.Name != Server.HTTP.Session.SessionCookieName);

            if (requesHasCookies)
            {
                var cookieText = new StringBuilder();

                cookieText.AppendLine("<h1>Cookies</h1>");
                cookieText.Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in this.Request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText
                       .Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                    cookieText.Append("</tr>");
                }
                cookieText.Append("</table>");
                return Html(cookieText.ToString());
            }
            else
            {
                var cookies = new CookieCollection();
                cookies.Add("My-Cookie", "Value-1");
                cookies.Add("My-Second-Cookie", "Value-2");

                return Html("<h1>Cookies Set</h1>", cookies);
            }
        }

        public Response Session()
        {
            var sessionExists = this.Request.Session.ContainsKey(Server.HTTP.Session.SessionCurrentDayKey);

            if (sessionExists)
            {
                var currentDate = this.Request.Session[Server.HTTP.Session.SessionCurrentDayKey];
                return Text($"Stored date: {currentDate}");
            }

            return Text($"Date stored!");
        }

        private static async Task<string> DownloadWebSiteContent(string url)
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {
                var response = await httpClient.GetAsync(url);

                var html = await response.Content.ReadAsStringAsync();

                return html.Substring(0, 500);
            }
        }

        private static async Task DownloadSitesAsText(string fileName, string[] urls)
        {
            var downloads = new List<Task<string>>();

            foreach (var url in urls)
            {
                downloads.Add(DownloadWebSiteContent(url));
            }

            var responses = await Task.WhenAll(downloads);

            var responseString = string.Join(Environment.NewLine + new string('-', 100), responses);

            await System.IO.File.WriteAllTextAsync(fileName, responseString);
        }
    }
}
