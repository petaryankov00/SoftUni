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
        ICollection<AllTripsViewModel> GetAll();

        void AddTrip(AddTripViewModel model);
    }
}
