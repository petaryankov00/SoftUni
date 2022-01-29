using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Models;
using SharedTrip.Services;
namespace SharedTrip.Controllers
{
    [Authorize]
    public class TripsController : Controller
    {
        private readonly ITripService tripService;
        private readonly IValidator validator;

        public TripsController()
        {      
            tripService = new TripService();
            validator = new Validator();
        }

        public HttpResponse All()
        {      
            var tripsToReturn =  tripService.GetAll();

            return this.View(tripsToReturn);
        }

        public HttpResponse Add() => this.View();

        [HttpPost]
        public HttpResponse Add(AddTripViewModel model)
        {
            if (!validator.ValidateTrip(model))
            {
                return Text("Unvalid trip data.");
            }

            tripService.AddTrip(model);

            return Redirect("/Trips/All");
        }

        public HttpResponse Details(string tripId)
        {
            var trip = tripService.GetTripById(tripId);

            if (trip == null)
            {
                return Text("Invalid TripId.");
            }

            return this.View(trip);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            var userId = this.User.Id;

            var isValidToJoin = validator.ValidateUserToJoinTrip(tripId, userId);

            if (!isValidToJoin)
            {
                return Text("User already in trip or trip has no free seats.");
            }

            tripService.AddUserToTrip(tripId, userId);

            return Redirect("/");
        }
    }
}
