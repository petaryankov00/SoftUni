using CarShop.Models;
using CarShop.Services.Contract;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        [Authorize]
        public HttpResponse Add()
            => this.View();

        [HttpPost]
        [Authorize]
        public HttpResponse Add(CarInputModel model)
        {
            var carValidation = carService.ValidateCar(model);

            if (!carValidation.isValid)
            {
                return View(carValidation.errors, "/Error");
            }

            carService.AddCar(model, this.User.Id);

            return Redirect("/Cars/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var cars = carService.GetAllCars(this.User.Id);

            return this.View(cars);
        }

    }

}
