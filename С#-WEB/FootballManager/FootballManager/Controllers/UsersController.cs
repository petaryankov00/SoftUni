using FootballManager.Services.Contracts;
using FootballManager.ViewModels;
using FootballManager.ViewModels.Users;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Collections.Generic;

namespace FootballManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UserRegisterModel model)
        {
            var errors = userService.CreateUser(model);

            if (errors.Count > 0)
            {
                return View("/Error", errors);
            }

            return Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(UserLoginModel model)
        {
            var (isLoggedIn, userId) = userService.LoginUser(model);

            if (!isLoggedIn)
            {
                return View("/Error", new List<ErrorViewModel> { new ErrorViewModel 
                { Message = "Invalid Username or Password." } });
            }

            this.SignIn(userId);
            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();
            return Redirect("/");
        }
    }
}
