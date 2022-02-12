using CarShop.Data;
using CarShop.Data.Data.Models;
using CarShop.Models;
using CarShop.Services.Contract;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CarShop.Services
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext dbContext;

        public CarService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddCar(CarInputModel model, string userId)
        {
            var car = new Car
            {
                Model = model.Model,
                Year = model.Year,
                PictureURL = model.Image,
                PlateNumber = model.PlateNumber,
                OwnerId = userId
            };

            dbContext.Cars.Add(car);
            dbContext.SaveChanges();
        }

        public IEnumerable<AllCarsViewModel> GetAllCars(string userId)
        {
            var currentUser = dbContext.Users
                .Where(x => x.Id == userId)
                .FirstOrDefault();

            var carsQuery = dbContext.Cars
                .AsQueryable();

            if (currentUser.IsMechanic)
            {
                carsQuery = carsQuery
                    .Where(x => x.Issues.Any(i => i.IsFixed == false));
            }
            else
            {
                carsQuery = carsQuery
                   .Where(x => x.OwnerId == userId);
            }

            var cars = carsQuery
                .Select(x => new AllCarsViewModel
                {
                    CarId = x.Id,
                    PlateNumber = x.PlateNumber,
                    ImageURL = x.PictureURL,
                    FixedIssues = x.Issues.Where(x => x.IsFixed == true).Count(),
                    RemainingIssues = x.Issues.Where(x => x.IsFixed == false).Count(),
                    Model = $"{x.Model} {x.Year}"
                })
                .ToList();

            return cars;
        }

        public (bool isValid, IEnumerable<string> errors) ValidateCar(CarInputModel model)
        {
            List<string> errors = new List<string>();
            bool isValid = true;

            if (model.Model == null || model.Model.Length < 5 || model.Model.Length > 20)
            {
                errors.Add("Invalid car model!");
                isValid = false;
            }

            if (model.Image == null)
            {
                errors.Add("Image is required!");
                isValid = false;
            }

            if (!Regex.IsMatch(model.PlateNumber, @"[A-Z]{2}[0-9]{4}[A-Z]{2}"))
            {
                errors.Add("Invalid plate number");
                isValid = false;
            }

            return (isValid, errors);
        }
    }
}
