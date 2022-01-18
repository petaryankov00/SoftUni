using MyWebServer.Server;
using MyWebServer.Server.HTTP;
using MyWebServer.Server.Responses;
using System.Text;
using System.Web;

namespace MyWebServer.Demo
{
    public class StartUp
    {
        private const string HtmlForm = @"<form action='/HTML' method='POST'>
                                            Name: <input type='text' name='Name'/>
                                            Age: <input type='number' name ='Age'/>
                                            <input type='submit' value ='Save'/>
                                           </form>";

        private const string DownloadForm = @"<form action='/Content' method='POST'>
                                                <input type='submit' value = 'Download Sites Content' />
                                              </form>";

        private const string FileName = "content.txt";

        private const string LoginForm = @"<form action='/Login' method='POST'>
                                               Username: <input type='text' name='Username'/>
                                               Password: <input type='text' name='Password'/>
                                               <input type='submit' value ='Log In' /> 
                                           </form>";

        private const string Username = "Pesho00";
        private const string Password = "123456";


        public static async Task Main()

        {
            await DownloadSitesAsText(StartUp.FileName, new string[]
            {
                "https://judge.softuni.org/",
                "https://wikipedia.bg/"
            });

            var server = new HttpServer(routes => routes
            .MapGet("/", new TextResponse("Hello from the server!"))
            .MapGet("/Redirect", new RedirectResponse("https://softuni.org/"))
            .MapGet("/HTML", new HtmlResponse(StartUp.HtmlForm))
            .MapPost("/HTML", new TextResponse("", StartUp.AddFormDataAction))
            .MapGet("/Content", new HtmlResponse(StartUp.DownloadForm))
            .MapPost("/Content", new TextFileResponse(StartUp.FileName))
            .MapGet("/Cookies", new HtmlResponse("", StartUp.AddCookiesAction))
            .MapGet("/Session", new TextResponse("",StartUp.DisplaySessionInfoAction))
            .MapGet("/Login", new HtmlResponse(StartUp.LoginForm))
            .MapPost("/Login", new HtmlResponse("",StartUp.LoginAction))
            .MapGet("/Logout",new HtmlResponse("",StartUp.LogoutAction))
            .MapGet("/UserProfile", new HtmlResponse("",StartUp.GetUserDataAction)));

            await server.Start();

        }

        private static void GetUserDataAction(Request request, Response response)
        {
            if (request.Session.ContainsKey(Session.SessionUserKey))
            {
                response.Body = "";
                response.Body += $"<h2>Currently logged in user with username: {Username}</h2>";
            }
            else
            {
                response.Body = "";
                response.Body += $"<h2>You should first login - <br> <a href='/Login'>Login</a> </h2>";
            }
        }


        private static void LogoutAction(Request request, Response response)
        {
            var sessionBefore = request.Session;
            request.Session.Clear();
            response.Body = "";
            response.Body = "<h1>Logged out succesfull!</h1>";
            var sessionAfter = request.Session;
        }

        private static void LoginAction(Request request, Response response)
        {
            request.Session.Clear();
            var bodyText = "";
            var usernameMatches = request.Form["Username"] == StartUp.Username;
            var passwordMatches = request.Form["Password"] == StartUp.Password;

            if (usernameMatches && passwordMatches)
            {
                request.Session[Session.SessionUserKey] = "MyUser-KeyId";
                response.Cookies.Add(Session.SessionCookieName, request.Session.Id);

                bodyText = "<h1>Logged succesfully!</h1>";
            }
            else
            {
                bodyText = StartUp.LoginForm;
            }

            response.Body = "";
            response.Body = bodyText;
        }

        private static void DisplaySessionInfoAction(Request request, Response response)
        {
            var sessionExists = request.Session.ContainsKey(Session.SessionCurrentDayKey);

            var bodyText = "";

            if (sessionExists)
            {
                var currentDate = request.Session[Session.SessionCurrentDayKey];
                bodyText = $"Stored date: {currentDate}";
            }
            else
            {
                bodyText = $"Date stored!";
            }

            response.Body = "";
            response.Body = bodyText;
        }

        private static void AddCookiesAction(Request request, Response response)
        {
            var requesHasCookies = request.Cookies
                .Any(c => c.Name != Session.SessionCookieName);
            var bodyText = "";

            if (requesHasCookies)
            {
                var cookieText = new StringBuilder();

                cookieText.AppendLine("<h1>Cookies</h1>");
                cookieText.Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText
                       .Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                    cookieText.Append("</tr>");
                }
                cookieText.Append("</table>");
                bodyText = cookieText.ToString();
            }
            else
            {
                bodyText = "<h1>Cookies set!</h1>";
            }

            response.Body = bodyText;           

            if (!requesHasCookies)
            {
                response.Cookies.Add("My-Cookie", "Value-1");
                response.Cookies.Add("My-Second-Cookie", "Value-2");
            }
        }
            

        private static void AddFormDataAction(Request request, Response response)
        {
            response.Body = "";

            foreach (var (key, value) in request.Form)
            {
                response.Body += $"{key} - {value}";
                response.Body += Environment.NewLine;
            }
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
            
            await File.WriteAllTextAsync(fileName, responseString);
        }
    }
}