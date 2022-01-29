using SharedTrip.Data;
using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly ApplicationDbContext dbContext;

        public TripService()
        {
            dbContext = new ApplicationDbContext();
        }

        public ICollection<AllTripsViewModel> GetAll()
        {
            var trips = dbContext.Trips
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

            dbContext.Trips.Add(trip);
            dbContext.SaveChanges();
        }

        public TripDetailsViewModel GetTripById(string tripId)
        {

            var trip = dbContext
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

            dbContext.UsersTrips.Add(userTrip);
            dbContext.SaveChanges();
        }
    }
}
