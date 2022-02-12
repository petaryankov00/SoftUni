using CarShop.Models.Users;
using System.Collections.Generic;

namespace CarShop.Services.Contracts
{
    public interface IUserService
    {
        (bool isValid, IEnumerable<string> errors) ValidateUser(UserRegisterModel model);

        (bool isValid, string userId) ValidateLogin(UserLoginModel model);

        void RegisterUser(UserRegisterModel model);
    }
}
