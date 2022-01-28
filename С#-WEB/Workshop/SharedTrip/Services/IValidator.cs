using MyWebServer.Http;
using SharedTrip.Models;

namespace SharedTrip.Services
{
    public interface IValidator
    {
        bool ValidateUser(RegstierUserViewModel model);

        bool ValidateTrip(AddTripViewModel model);
    }
}
