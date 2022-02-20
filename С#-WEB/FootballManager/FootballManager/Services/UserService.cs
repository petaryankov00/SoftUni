using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.Services.Contracts;
using FootballManager.ViewModels;
using FootballManager.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FootballManager.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public UserService(IRepository repo,IValidationService validationService)
        {
            this.repo = repo;
            this.validationService = validationService;
        }

        public List<ErrorViewModel> CreateUser(UserRegisterModel model)
        {
            var errors = validationService.ValidateModel(model);

            if (errors.Count > 0)
            {
                return errors;
            }

            var isUserExist = repo.All<User>()
                .Any(x => x.Username == model.Username || x.Email == model.Email);

            if (isUserExist)
            {
                errors.Add(new ErrorViewModel { Message = "Username or email already exist." });
                return errors;
            }

            var hashedPassword = CalculateHash(model.Password);

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = hashedPassword,
            };

            repo.Add(user);
            repo.SaveChanges();

            return errors;
        }


        public (bool isValid,string userId) LoginUser(UserLoginModel model)
        {
            var hashedPassword = CalculateHash(model.Password);

            var user = repo.All<User>()
                .Where(x => x.Username == model.Username && x.Password == hashedPassword)
                .FirstOrDefault();

            if (user == null)
            {
                return (false,null);
            }

            return (true,user.Id);
        }

        private static string CalculateHash(string password)
        {
            byte[] passworArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passworArray));
            }
        }
    }
}
