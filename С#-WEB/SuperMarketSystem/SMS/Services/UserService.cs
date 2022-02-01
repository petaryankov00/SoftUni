using SMS.Common;
using SMS.Data;
using SMS.Data.Models;
using SMS.Models;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace SMS.Services
{
    public class UserService : IUserService
    {
        private readonly SMSDbContext dbContext;

        public UserService()
        {
            dbContext = new SMSDbContext();
        }

        public string LoginUser(UserLoginInputModel model)
        {
            var user = dbContext
                .Users
                .FirstOrDefault(x => x.Username == model.Username);

            var isMatch = SecurePasswordHasher.Verify(model.Password, user.Password);

            if (!isMatch)
            {
                return null;
            }

            return user.Id;
        }

        public bool RegisterUser(UserRegisterInputModel model)
        {
            if (!IsValid(model))
            {
                return false;
            }

            var hashedPassword = SecurePasswordHasher.Hash(model.Password);

            var user = new User
            {
                Username = model.Username,
                Password = hashedPassword,
                Email = model.Email,
                Cart = new Cart()
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return true;
        }

        private bool IsValid(UserRegisterInputModel model)
        {
            if (model.Username == null || model.Password == null
                || model.ConfirmPassword == null || model.Password == null)
            {
                return false;
            }
            if (model.Username.Length < 6 || model.Username.Length > 20)
            {
                return false;
            }
            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                return false;
            }
            if (model.Password != model.ConfirmPassword)
            {
                return false;
            }
            if (!MailAddress.TryCreate(model.Email,out _))
            {
                return false;
            }

            var isUserExist = dbContext.Users
                .Any(x=>x.Username == model.Username || x.Email == model.Email);

            if (isUserExist)
            {
                return false;
            }

            return true;
        }
    }
}
