using Microsoft.EntityFrameworkCore;
using SharedTrip.Data;
using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly ApplicationDbContext context;

        public TripService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ICollection<AllTripsViewModel> GetAll()
        {
            var trips = context
                .Trips
                .Select(x => new AllTripsViewModel
                {
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = x.Seats,
                    TripId = x.Id
                })
                .ToList();

            return trips;
        }

        public void AddTrip(AddTripViewModel model)
        {
            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = DateTime.ParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                ImagePath = model.ImagePath,
                Seats = model.Seats,
                Description = model.Description,
            };

            context.Trips.Add(trip);
            context.SaveChanges();
        }

        public TripDetailsViewModel GetTripById(string tripId)
        {

            var trip = context
                .Trips
                .Where(x => x.Id == tripId)
                .Select(x => new TripDetailsViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                    Description = x.Description,
                    ImagePath = x.ImagePath,
                    Seats = x.Seats
                })
                .FirstOrDefault();

            return trip;
        }

        public void AddUserToTrip(string tripId, string userId)
        {
            var userTrip = new UserTrip
            {
                UserId = userId,
                TripId = tripId
            };

            context.UsersTrips.Add(userTrip);
            context.SaveChanges();
        }
    }
}
