namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Common;
    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.Services;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IValidator validator;
        private readonly IUserService userService;  

        public UsersController()
        {
            context = new ApplicationDbContext();
            validator = new Validator();
            userService = new UserService();
        }

        public HttpResponse Register() => this.View();

        [HttpPost]
        public HttpResponse Register(RegstierUserViewModel model)
        {
            if (!validator.ValidateUser(model))
            {
                return this.Text("Invalid Register Form.");
            }
            
            userService.RegisterUser(model);
            return Redirect("/Users/Login");
        }

        public HttpResponse Login() => this.View();

        [HttpPost]
        public HttpResponse Login(LoginUserViewModel model) 
        {
            var user = context.Users
                .FirstOrDefault(x=>x.Username == model.Username);
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
            return Redirect("/Index");
        }
    }
}

