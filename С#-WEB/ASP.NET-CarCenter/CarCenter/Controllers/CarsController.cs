using CarCenter.Models;
using CarCenter.Services.Contracts;
using CarCenter.ViewModels.Cars;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarCenter.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        [Authorize]
        public IActionResult Add()
        {
            var carCategories = carService.AllCategories();
            return View(carCategories);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(CarInputModel model)
        {
            if (!ModelState.IsValid)
            {
                var carCategories = carService.AllCategories();
                return View(carCategories);
            }

            try
            {
                carService.AddCar(model);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel() { Message = ex.Message });
            }

            return Redirect("/");
        }

        [Authorize]
        public IActionResult All()
        {
            var cars = carService.AllCars();
            return View(cars);
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            try
            {
                var car = carService.CarDetails(id);
                return View(car);
            }
            catch (Exception ex)
            {
                return View("Error",new ErrorViewModel() { Message = ex.Message });
            }
            
        }

        [Authorize]
        public IActionResult Delete(string id) 
        {
            try
            {
                carService.DeleteCar(id);
                return Redirect("/");
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel() { Message = ex.Message });
            }
        }


    }

}
