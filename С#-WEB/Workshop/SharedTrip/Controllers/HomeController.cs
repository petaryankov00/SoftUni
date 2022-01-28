namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            if (this.Request.Session.Contains(UserSessionKey))
            {
                return Redirect("/Trips/All");
            }
            return this.View();
        }
    }
}