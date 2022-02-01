using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Models;
using SMS.Services;

namespace SMS.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Login()
            => this.View();

        [HttpPost]
        public HttpResponse Login(UserLoginInputModel model)
        {
            var userId = userService.LoginUser(model);

            if (userId == null)
            {
                return this.View();
            }

            this.SignIn(userId);
            return this.Redirect("/");
        }

        public HttpResponse Register()
            =>  this.View();

        [HttpPost]
        public HttpResponse Register(UserRegisterInputModel model)
        {
            if (!userService.RegisterUser(model))
            {
                return this.View();
            }

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }

    }
}
