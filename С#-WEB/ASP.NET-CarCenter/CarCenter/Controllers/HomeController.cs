using CarCenter.Models;
using CarCenter.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarCenter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService carService;

        public HomeController(ICarService carService)
        {
            this.carService = carService;
        }
        
        public IActionResult Index()
        {
            var cars = carService.GetCarsForHomePage();
            return View(cars);
        }

        
    }
}
