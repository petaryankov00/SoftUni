using CarCenter.Data.Models;
using CarCenter.ViewModels.Cars;
using System.Collections.Generic;
using System.Linq;

namespace CarCenter.Tests.Controllers.Data
{
    public static class CarsData
    {
        public static IEnumerable<Category> Categories
               => Enumerable.Range(0, 7).Select(x => new Category());

        public static CarInputModel InvalidCar
            => new CarInputModel
            {
                ImageURL = "asfsaf",
                Brand = "bmw m2",
                Category = "SUV",
                PlateNumber = "ST22ST",
                Year = 1900
            };

        public static CarInputModel ValidCar
           => new CarInputModel
           {
               ImageURL = "https://webnews.bg/uploads/images/38/5638/245638/768x432.jpg?_=1469194303",
               Brand = "BMW M2",
               Category = "Luxury",
               PlateNumber = "ST2222ST",
               Year = 2000
           };

        public static IEnumerable<Car> TenCars
                   => Enumerable.Range(0, 10).Select(x => new Car());
    }
}
