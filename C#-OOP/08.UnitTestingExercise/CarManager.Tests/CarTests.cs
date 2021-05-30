
using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car("Make", "Model", 10, 80);
        }


        [Test]
        [TestCase("","Model",10,80)]
        [TestCase(null,"Model",10,80)]
        [TestCase("Make","",10,80)]
        [TestCase("Make", null,10,80)]
        [TestCase("Make", "Model", -1, 80)]
        [TestCase("Make", "Model", 0, 80)]
        [TestCase("Make", "Model", 10, -1)]
        [TestCase("Make", "Model", 10, 0)]
        public void When_DataIsInvalidThrowException(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void When_DataIsValid()
        {
            string make = "Make";
            string model = "Model";
            double fuelConsumption = 10;
            double fuelCapacity = 80;

            Assert.AreEqual(car.Make, make);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
            
        }


        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void When_FuelToRefuelIsNegative_ShouldThrowException(double fuelToRefuel)
        {
            Car car = new Car("Make", "Model", 10, 80);
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelToRefuel);
            });
        }

        [Test]
        public void When_FuelAmountIsLegit()
        {
            car.Refuel(car.FuelCapacity / 2);
            Assert.AreEqual(car.FuelAmount, car.FuelCapacity / 2);
        }

        [Test]
        public void When_FuelToRefuelIsMoreThanCapacity()
        {
            double refuelAmount = car.FuelCapacity * 1.2;
            car.Refuel(refuelAmount);
            Assert.AreEqual(car.FuelAmount, car.FuelCapacity);
        }

        [Test]
        public void When_DriveCarAndFuelNeededIsMoreThanAmount_ShouldThrowException()
        {
            double distance = 20;
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            });
        }

        [Test]
        public void When_FuelIsEnoughToDrive_ShouldDecreaseAmount()
        {
            car.Refuel(car.FuelCapacity);
            double distance = 100;
            double fuelNeeded = car.FuelConsumption;
            car.Drive(distance);
            Assert.AreEqual(car.FuelAmount, car.FuelCapacity - fuelNeeded);
        }
    }
}