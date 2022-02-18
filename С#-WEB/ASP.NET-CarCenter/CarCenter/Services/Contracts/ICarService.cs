using CarCenter.ViewModels.Cars;
using CarCenter.ViewModels.Categories;
using System.Collections.Generic;

namespace CarCenter.Services.Contracts
{
    public interface ICarService
    {
        IEnumerable<CarHomeViewModel> GetCarsForHomePage();

        CarInputModel AllCategories();

        void AddCar(CarInputModel model);

        List<AllCarsViewModel> AllCars();

        CarDetailsViewModel CarDetails(string id);

        void DeleteCar(string id);
    }
}
