using MyWebServer.Controllers;
using MyWebServer.Http;

namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Register()
            => this.View();

        public HttpResponse Login()
            => this.View();

    }
}
