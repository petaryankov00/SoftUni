using SMS.Models;

namespace SMS.Services
{
    public interface IUserService
    {
        string LoginUser(UserLoginInputModel model);

        bool RegisterUser(UserRegisterInputModel model);
    }
}
