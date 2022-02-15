using Git.InputModels;
using Git.ViewModels;

namespace Git.Services.Contracts
{
    public interface IUsersService
    {
        (ErrorViewModel error, bool isValid) CreateUser(CreateUserInputModel model);

        (string userId, bool isValid) LoginUser(LoginUserInputModel model);
    }
}
