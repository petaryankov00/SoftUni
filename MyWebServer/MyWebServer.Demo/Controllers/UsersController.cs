using MyWebServer.Server.HTTP;

namespace MyWebServer.Demo.Controllers
{
    public class UsersController : Controller
    {
        private const string Username = "Pesho00";
        private const string Password = "123456";

        public UsersController(Request request)
            : base(request)
        {
        }


        public Response Login() => View();

        public Response LoginUser()
        {
            this.Request.Session.Clear();
            var usernameMatches = this.Request.Form["Username"] == UsersController.Username;
            var passwordMatches = this.Request.Form["Password"] == UsersController.Password;

            if (usernameMatches && passwordMatches)
            {
                if (!this.Request.Session.ContainsKey(Session.SessionUserKey))
                {
                    this.Request.Session[Session.SessionUserKey] = "MyUserId";
                    var cookies = new CookieCollection();
                    cookies.Add(Session.SessionCookieName, this.Request.Session.Id);
                    cookies.Add("LogInfo", "Authenticated");

                    return Html("<h1>Logged succesfully!</h1>", cookies);

                }

                return Html("<h1>Logged succesfully!</h1>");

            }

            return Redirect("/Login");
        }


        public Response Logout()
        {
            this.Request.Session.Clear();

            return Html("<h2>Logged out succesfully<h2>");
        }

        public Response GetUserData()
        {
            if (this.Request.Session.ContainsKey(Session.SessionUserKey) || this.Request.Cookies.Contains("LogInfo"))
            {
                return Html($"<h2>Currently logged in user with username: {Username}</h2>");
            }

            return Html($"<h2>You should first login - <br> <a href='/Login'>Login</a> </h2>");
        }
    }
}
