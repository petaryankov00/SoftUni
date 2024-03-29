﻿using CarCenter.Controllers;
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
                .WithData(TestData.TenCars)
                .Calling(x=>x.Index())
                .ShouldReturn()
                .View(v => v
                .WithModelOfType<IEnumerable<CarHomeViewModel>>()
                .Passing(x=>Assert.Equal(10, TestData.TenCars.Count())));
        }

    }
}

