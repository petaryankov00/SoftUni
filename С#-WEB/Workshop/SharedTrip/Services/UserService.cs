namespace SharedTrip.Services
{
    using SharedTrip.Common;
    using SharedTrip.Data;
    using SharedTrip.Models;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task RegisterUser(RegstierUserViewModel model)
        {
            var hashPassword = SecurePasswordHasher.Hash(model.Password);

            var user = new User
            {
                Username = model.Username,
                Password = hashPassword,
                Email = model.Email,
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
    }
}
