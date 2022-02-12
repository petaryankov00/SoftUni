using CarShop.Data;
using CarShop.Data.Data.Models;
using CarShop.Models.Users;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void RegisterUser(UserRegisterModel model)
        {
            string hashedPassword  = SecurePasswordHasher.Hash(model.Password);
            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = hashedPassword,
                IsMechanic = model.UserType == "Mechanic" ? true : false
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }



        public (bool isValid, IEnumerable<string> errors) ValidateUser(UserRegisterModel model)
        {
            List<string> errors = new List<string>();
            bool isValid = true;
            var usernames = dbContext.Users
                .Select(x => new
                {
                    x.Username,
                    x.Email
                })
                .ToList();


            if (model.Username == null || model.Username.Length < 4
                || model.Username.Length > 20 || usernames.Any(x => x.Username == model.Username))
            {
                errors.Add("Username is not valid!");
                isValid = false;
            }

            if (model.Password == null || model.Password.Length < 4
                || model.Password.Length > 20 || model.Password != model.ConfirmPassword)
            {
                errors.Add("Password is not valid!");
                isValid = false;
            }

            if (model.Email == null || usernames.Any(x=>x.Email == model.Email))
            {
                errors.Add("Email is not valid!");
                isValid = false;
            }

            return (isValid,errors);

        }

        public (bool isValid, string userId) ValidateLogin(UserLoginModel model)
        {
            var user = dbContext.Users
                .Where(x => x.Username == model.Username)
                .FirstOrDefault();

            if (user != null)
            {
                bool isValidPassword = SecurePasswordHasher.Verify(model.Password, user.Password);
                if (isValidPassword)
                {
                    return (true, user.Id);
                }
            }

            return (false, "");
         
        }

    }
}
