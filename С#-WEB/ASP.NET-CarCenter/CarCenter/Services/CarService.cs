using CarCenter.Data.Common;
using CarCenter.Data.Models;
using CarCenter.Services.Contracts;
using CarCenter.ViewModels.Cars;
using CarCenter.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarCenter.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository repo;
        public CarService(IRepository repo)
        { 
            this.repo = repo;
        }

        public void AddCar(CarInputModel model)
        {
            var brand = repo.All<Brand>()
                .FirstOrDefault(x => x.Name == model.Brand);

            if (brand == null)
            {
                brand = new Brand()
                {
                    Name = model.Brand
                };
            }

            var category = repo.All<Category>()
                .FirstOrDefault(x => x.Type == model.Category);

            if (category == null)
            {
                throw new ArgumentException("Invalid category");
            }

            var car = new Car()
            {
                Brand = brand,
                ImageURL = model.ImageURL,
                PlateNumber = model.PlateNumber,
                Year = model.Year,
                Category = category
            };

            repo.Add(car);
            repo.SaveChanges();
        }

        public List<AllCarsViewModel> AllCars()
        {
            var cars = repo.All<Car>()
                .Select(x => new AllCarsViewModel()
                {
                    Id = x.Id,
                    Brand = x.Brand.Name,
                    ImageURL = x.ImageURL
                })
                .ToList();

            return cars;
        }

        public CarInputModel AllCategories()
        {
            var categories = repo.All<Category>()
                .Select(x => new CategoryFormModel
                {
                    Name = x.Type
                })
                .ToList();

            var car = new CarInputModel
            {
                Categories = categories
            };

            return car;
        }

        public CarDetailsViewModel CarDetails(string id)
        {
            var car = repo.All<Car>()
                .Where(x=>x.Id == id)
                .Select(x=> new CarDetailsViewModel
                {
                    Brand = x.Brand.Name,
                    Category = x.Category.Type,
                    ImageURL = x.ImageURL,
                    IssuesCount = x.Issues.Where(i=>i.IsFixed == false).Count(),
                    Year = x.Year,
                    Id = x.Id,
                    PlateNumber = x.PlateNumber,
                })
                .FirstOrDefault();

            if (car == null)
            {
                throw new InvalidOperationException("There is no such car in the system!");
            }

            return car;
        }

        public void DeleteCar(string id)
        {
            var car = repo.All<Car>()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (car == null)
            {
                throw new InvalidOperationException("Car is not found!");
            }

            repo.Remove<Car>(car);
            repo.SaveChanges();
        }

        public IEnumerable<CarHomeViewModel> GetCarsForHomePage()
        {
            var cars = repo.All<Car>()
                .Select(x => new CarHomeViewModel
                {
                    Id = x.Id,
                    ImageURL = x.ImageURL,
                    Model = x.Brand.Name,
                    Year = x.Year
                })
                .Take(10)
                .ToList();

            return cars;
        }
    }
}
