using FootballManager.ViewModels;
using FootballManager.ViewModels.Users;
using System.Collections.Generic;

namespace FootballManager.Services.Contracts
{
    public interface IUserService
    {
        List<ErrorViewModel> CreateUser(UserRegisterModel model);

        (bool isValid,string userId) LoginUser(UserLoginModel model);
    }
}
