namespace SharedTrip.Controllers
{
    using Microsoft.EntityFrameworkCore;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Common;
    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.Services;
    using System.Threading.Tasks;

    public class UsersController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IValidator validator;
        private readonly IUserService userService;  

        public UsersController(ApplicationDbContext context,IValidator validator,IUserService userService)
        {
            this.context = context;
            this.validator = validator;
            this.userService = userService;
        }

        public HttpResponse Register() => this.View();

        [HttpPost]
        public async Task<HttpResponse> Register(RegstierUserViewModel model)
        {
            if (!validator.ValidateUser(model))
            {
                return this.Text("Invalid Register Form.");
            }
            
            await userService.RegisterUser(model);
            return Redirect("/Users/Login");
        }

        public HttpResponse Login() => this.View();

        [HttpPost]
        public async Task<HttpResponse> Login(LoginUserViewModel model) 
        {
            var user = await this.context
                .Users
                .FirstOrDefaultAsync(x=>x.Username == model.Username);

            var isUserValid = SecurePasswordHasher.Verify(model.Password, user.Password);

            if (!isUserValid)
            {
                return this.Text("Invalid Username or Password.");
            }

            this.SignIn(user.Id);
            return Redirect("/Trips/All");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return Redirect("/");
        }
    }
}

