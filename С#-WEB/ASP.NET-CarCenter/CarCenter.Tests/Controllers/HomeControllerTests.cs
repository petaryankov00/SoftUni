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
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionShouldReturnViewWithTenCars()
        {
            MyMvc
                .Controller<HomeController>()
                .WithData(CarsData.TenCars)
                .Calling(x=>x.Index())
                .ShouldReturn()
                .View(v => v
                .WithModelOfType<IEnumerable<CarHomeViewModel>>()
                .Passing(x=>Assert.Equal(10, CarsData.TenCars.Count())));
        }

    }
}

