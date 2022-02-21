using CarCenter.Controllers;
using CarCenter.Models;
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
                .WithData(TestData.Categories)
                .Calling(x => x.Add())
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View(v => v.
                WithModelOfType<CarInputModel>().
                Passing(x => Assert.Equal(7, TestData.Categories.Count())));
        }

        [Fact]
        public void AddPostShouldRefreshWhenCreateIsNotSuccesfull()
        {
            MyMvc
                .Controller<CarsController>()
                .Calling(x => x.Add(TestData.InvalidCar))
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldHave()
                .InvalidModelState()
                .AndAlso()
                .ShouldReturn()
                .View(v => v.
                WithModelOfType<CarInputModel>().
                Passing(x => Assert.Equal(7, TestData.Categories.Count())));
        }

        [Fact]
        public void AddPostShouldHaveValidModelStateAndRedirect()
        {
            MyMvc
                .Controller<CarsController>()
                .WithData(data => data
                 .WithEntities(entities => entities.AddRange(TestData.CarDb)))
                .Calling(x => x.Add(TestData.ValidCar))
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForAuthorizedRequests().RestrictingForHttpMethod(HttpMethod.Post))
                .AndAlso()
                .ShouldHave()
                .ValidModelState()
                .AndAlso()
                .ShouldReturn()
                .Redirect("/");
        }

        [Fact]
        public void AllGetShouldReturnViewWithCars()
        {
            MyMvc
                .Controller<CarsController>()
                .WithData(data => data
                 .WithEntities(entities => entities.AddRange(TestData.CarDb)))
                .Calling(x => x.All())
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View(view => view.WithModelOfType<List<AllCarsViewModel>>()
                .Passing(x => x.Count == 1));
        }

        [Fact]
        public void DetailsGetShouldReturnCorrectCarDetails()
        {
            MyController<CarsController>
                 .Instance()
                 .WithData(data => data
                 .WithEntities(entities => entities.AddRange(TestData.CarDb)))
                 .Calling(x => x.Details("TestId"))
                 .ShouldHave()
                 .ActionAttributes(a => a.RestrictingForAuthorizedRequests())
                 .AndAlso()
                 .ShouldReturn()
                 .View(view => view
                 .WithModelOfType<CarDetailsViewModel>()
                 .Passing(x => Assert.Equal("TestId", x.Id)));
        }

        [Fact]
        public void DetailsGetShouldReturnErrorWithInvalidId()
        {
            MyController<CarsController>
                .Instance()
                .WithData(data => data
                .WithEntities(entities => entities.AddRange(TestData.CarDb)))
                .Calling(x => x.Details("InvaliId"))
                .ShouldReturn()
                .View(view => view.WithName("Error").WithModelOfType<ErrorViewModel>());
        }

        [Fact]
        public void DeleteGetShouldRemoveCarAndReturnRedirect()
        {
            MyController<CarsController>
                .Instance()
                .WithData(data => data
                .WithEntities(entities => entities.AddRange(TestData.CarDb)))
                .Calling(x => x.Delete("TestId"))
                .ShouldReturn()
                .Redirect("/");
        }

        [Fact]
        public void DeleteGetShouldReturnErrorWhenIdIsInvalid()
        {
            MyController<CarsController>
                .Instance()
                .WithData(data => data
                .WithEntities(entities => entities.AddRange(TestData.CarDb)))
                .Calling(x => x.Delete("InvalidId"))
                .ShouldReturn()
                .View(view => view.WithName("Error").WithModelOfType<ErrorViewModel>());
        }

    }
}
