namespace SharedTrip.Services
{
    using SharedTrip.Common;
    using SharedTrip.Data;
    using SharedTrip.Models;
    using System;
    using System.Security.Cryptography;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService()
        {
            context = new ApplicationDbContext();
        }

        public void RegisterUser(RegstierUserViewModel model)
        {
            var hashPassword = SecurePasswordHasher.Hash(model.Password);

            var user = new User
            {
                Username = model.Username,
                Password = hashPassword,
                Email = model.Email,
            };

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
