using Git.Data;
using Git.Data.Models;
using Git.InputModels;
using Git.Services.Contracts;
using Git.ViewModels;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Git.Services
{
    public class UsersService : IUsersService
    {
        private readonly IValidationService validationService;
        private readonly ApplicationDbContext dbContext;

        public UsersService(IValidationService validationService, ApplicationDbContext dbContext)
        {
            this.validationService = validationService;
            this.dbContext = dbContext;
        }

        public (ErrorViewModel error, bool isValid) CreateUser(CreateUserInputModel model)
        {
            (bool isValid, var error) = validationService.ValidateModel(model);

            var isUserExist = dbContext
                .Users
                .Any(x => x.Username == model.Username || x.Email == model.Email);

            if (!isValid)
            {
                return (error, false);
            }

            if (isUserExist)
            {
                error.Errors.Add("Username or email already exist");
                return (error, false);  
            }

            var hashedPassword = CalculateHash(model.Password);

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = hashedPassword
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return (error, true);   
        }

        public (string userId, bool isValid) LoginUser(LoginUserInputModel model)
        {
            var hashedPassword = CalculateHash(model.Password);
            var user = dbContext.Users
                .Where(x => x.Username == model.Username && x.Password == hashedPassword)
                .FirstOrDefault();
            if (user == null)
            {
                return("", false);
            }
            var userId = user.Id;
            return (userId, true);

        }

        private string CalculateHash(string password)
        {
            byte[] passworArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passworArray));
            }
        }
    }
}
