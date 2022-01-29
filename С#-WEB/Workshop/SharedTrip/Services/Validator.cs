using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Models;
using System;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Services
{
    public class Validator : IValidator
    {
        private readonly ApplicationDbContext dbContext;

        public Validator()
        {
           dbContext = new ApplicationDbContext();
        }

        public bool ValidateUser(RegstierUserViewModel model)
        {
            if (dbContext.Users.Any(x => x.Username == model.Username || x.Email == model.Email))
            {
                return false;
            }
            if (model.Password != model.ConfirmPassword)
            {
                return false;
            }
            if (model.Username.Length < 6 || model.Username.Length > 20)
            {
                return false;
            }
            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                return false;
            }

            return true;
        }

        public bool ValidateTrip(AddTripViewModel model)
        {
            if (model.Seats < 2 || model.Seats > 6)
            {
                return false;
            }

            if (model.Description.Length > 80)
            {
                return false;
            }

            DateTime dateTime;

            bool isValidDateTime = DateTime.TryParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm",CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);

            if (!isValidDateTime)
            {
                return false;
            }

            return true;
        }

        public bool ValidateUserToJoinTrip(string tripId,string userId)
        {
            var isUserInTrip = dbContext.UsersTrips.Any(x => x.UserId == userId && x.TripId == tripId);

            if (isUserInTrip)
            {
                return false;
            }

            var trip = dbContext.Trips.FirstOrDefault(x => x.Id == tripId);
            trip.Seats--;

            if (trip.Seats < 0)
            {
                trip.Seats = 0; //Maybe not neseccary
                return false;
            }

            dbContext.SaveChanges();
            return true;
        }
    }
}
