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

        public async Task<ICollection<AllTripsViewModel>> GetAll()
        {
            var trips = await this.context
                .Trips
                .Select(x => new AllTripsViewModel
                {
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = x.Seats,
                    TripId = x.Id
                })
                .ToListAsync();

            return trips;
        }

        public async Task AddTrip(AddTripViewModel model)
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

            await context.Trips.AddAsync(trip);
            await context.SaveChangesAsync();
        }

        public async Task<TripDetailsViewModel> GetTripById(string tripId)
        {

            var trip = await this.context
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
                .FirstOrDefaultAsync();

            return trip;
        }

        public async Task AddUserToTrip(string tripId, string userId)
        {
            var userTrip = new UserTrip
            {
                UserId = userId,
                TripId = tripId
            };

            await context.UsersTrips.AddAsync(userTrip);
            await context.SaveChangesAsync();
        }
    }
}
