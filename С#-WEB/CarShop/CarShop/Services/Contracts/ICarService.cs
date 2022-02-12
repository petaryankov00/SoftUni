using CarShop.Models;
using System.Collections.Generic;

namespace CarShop.Services.Contract
{
    public interface ICarService
    {
        (bool isValid, IEnumerable<string> errors) ValidateCar(CarInputModel model,string userId);

        void AddCar(CarInputModel model,string userId);

        IEnumerable<AllCarsViewModel> GetAllCars(string userId);
    }
}
