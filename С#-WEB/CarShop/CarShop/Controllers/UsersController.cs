using CarShop.Models.Users;
using CarShop.Services;
using CarShop.Services.Contracts;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Collections.Generic;

namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Register()
            => this.View();

        public HttpResponse Login()
            => this.View();

        [HttpPost]
        public HttpResponse Register(UserRegisterModel model)
        {
            var (isValid,errors) = userService.ValidateUser(model);

            if (!isValid)
            {
                return View(errors, "/Error");
            }

            userService.RegisterUser(model);

            return Redirect("/Users/Login");
        }

        [HttpPost]
        public HttpResponse Login(UserLoginModel model)
        {
            var login = userService.ValidateLogin(model);

            if (!login.isValid)
            {
                return View(new List<string>() { "Invalid username or password" }, "/Error");
            }

            this.SignIn(login.userId);

            return Redirect("/");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }

    }
}
