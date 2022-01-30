namespace SharedTrip.Services
{
    using SharedTrip.Models;
    using System.Threading.Tasks;

    public interface IUserService
    {
        void RegisterUser(RegstierUserViewModel model);

    }
}
