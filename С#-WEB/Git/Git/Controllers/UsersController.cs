using Git.InputModels;
using Git.Services.Contracts;
using Git.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Register(CreateUserInputModel model)
        {
            (var error, bool isValid) = usersService.CreateUser(model);

            if (!isValid)
            {
                return View(error, "/Error");
            }

            return Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserInputModel model)
        {
            (string userId,bool isValid) = usersService.LoginUser(model);

            if (!isValid)
            {
                return View(new ErrorViewModel { Errors = { "Invalid username or password" } }, "/Error");
            }

            this.SignIn(userId);

            return Redirect("/");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }

    }
}
