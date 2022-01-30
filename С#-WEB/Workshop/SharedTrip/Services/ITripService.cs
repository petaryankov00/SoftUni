using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public interface ITripService
    {
        Task<ICollection<AllTripsViewModel>> GetAll();

        Task AddTrip(AddTripViewModel model);

        Task<TripDetailsViewModel> GetTripById (string tripId);

        Task AddUserToTrip(string tripId,string userId);
    }
}
