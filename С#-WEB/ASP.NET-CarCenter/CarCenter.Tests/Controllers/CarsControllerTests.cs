using CarCenter.Controllers;
using CarCenter.Data.Models;
using CarCenter.Tests.Controllers.Data;
using CarCenter.ViewModels.Cars;
using MyTested.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CarCenter.Tests.Controllers
{
    public class CarsControllerTests
    {
        [Fact]
        public void AddGetShouldReturnViewWithCategories()
        {
            MyMvc
                .Controller<CarsController>()
                .WithData(CarsData.Categories)
                .Calling(x => x.Add())
                .ShouldHave()
                .ActionAttributes(a=>a.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View(v => v.
                WithModelOfType<CarInputModel>().
                Passing(x => Assert.Equal(7, CarsData.Categories.Count() )));
        }

        [Fact]
        public void AddPostShouldRefreshWhenCreateIsNotSuccesfull()
        {
            MyMvc
                .Controller<CarsController>()
                .Calling(x => x.Add(CarsData.InvalidCar))
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldHave()
                .InvalidModelState()
                .AndAlso()
                .ShouldReturn()
                .View(v => v.
                WithModelOfType<CarInputModel>().
                Passing(x => Assert.Equal(7, CarsData.Categories.Count())));
        }

        [Fact]
        public void AddPostShouldHaveValidModelStateWithCorrectData()
        {
            MyMvc
                .Controller<CarsController>()
                .Calling(x => x.Add(CarsData.ValidCar))
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForAuthorizedRequests().RestrictingForHttpMethod(HttpMethod.Post))
                .AndAlso()
                .ShouldHave()
                .ValidModelState();
        }

        [Fact]
        public void AllGetShouldReturnViewWithCars()
        {
            MyMvc
                .Controller<CarsController>()
                .Calling(x => x.All())
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View(v => v.WithModelOfType<List<AllCarsViewModel>>());
        }
     
    }
}
