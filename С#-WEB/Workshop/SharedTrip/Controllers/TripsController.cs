using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Models;
using SharedTrip.Services;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    [Authorize]
    public class TripsController : Controller
    {
        private readonly ITripService tripService;
        private readonly IValidator validator;

        public TripsController(ITripService tripService,IValidator validator)
        {
            this.tripService = tripService;
            this.validator = validator;
        }

        public async Task<HttpResponse> All()
        {      
            var tripsToReturn =  await tripService.GetAll();

            return this.View(tripsToReturn);
        }

        public HttpResponse Add() => this.View();

        [HttpPost]
        public async Task<HttpResponse> Add(AddTripViewModel model)
        {
            if (!validator.ValidateTrip(model))
            {
                return Text("Unvalid trip data.");
            }

            await tripService.AddTrip(model);

            return Redirect("/Trips/All");
        }

        public async Task<HttpResponse> DetailsAsync(string tripId)
        {
            var trip = await tripService.GetTripById(tripId);

            if (trip == null)
            {
                return Text("Invalid TripId.");
            }

            return this.View(trip);
        }

        public async Task<HttpResponse> AddUserToTrip(string tripId)
        {
            var userId = this.User.Id;

            var isValidToJoin = validator.ValidateUserToJoinTrip(tripId, userId);

            if (!isValidToJoin)
            {
                return Text("User already in trip or trip has no free seats.");
            }

            await tripService.AddUserToTrip(tripId, userId);

            return Redirect("/");
        }
    }
}
