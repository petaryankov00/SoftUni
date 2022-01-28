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
        private readonly ApplicationDbContext context;

        public Validator()
        {
           context = new ApplicationDbContext();
        }

        public bool ValidateUser(RegstierUserViewModel model)
        {
            if (context.Users.Any(x => x.Username == model.Username || x.Email == model.Email))
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
    }
}
