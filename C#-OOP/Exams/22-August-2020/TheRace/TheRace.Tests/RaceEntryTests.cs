using NUnit.Framework;
using System;


namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry race;
        private UnitCar car;

        [SetUp]
        public void Setup()
        {
            car = new UnitCar("Model", 900, 6000);
            race = new RaceEntry();
        }

        [Test]
        public void When_RaceIsCreated()
        {
            var raceEntry = new RaceEntry();
            Assert.IsNotNull(raceEntry);
        }

        [Test]
        public void When_DriverIsAddedShouldIncreaseCounter()
        {
            UnitDriver driver = new UnitDriver("Pesho", car);
            race.AddDriver(driver);
            Assert.AreEqual(race.Counter, 1);
        }

        [Test]
        public void When_AddDriverNull()
        {
            UnitDriver driver = null;
            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(driver);
            });
        }

        [Test]
        public void When_AddExistingDriver()
        {
            UnitDriver driver = new UnitDriver("Pesho", car);
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(driver);
            });
        }

        [Test]
        public void When_AddDriverValid()
        {
            UnitDriver driver = new UnitDriver("Pesho", car);

            Assert.That(race.AddDriver(driver), Is.EqualTo($"Driver {driver.Name} added in race."));
        }

        [Test]
        public void When_ThereIsNotEnoughParticipants()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                race.CalculateAverageHorsePower();
            });
        }

        [Test]
        public void When_CalculateIsValid()
        {
            UnitCar testCar = new UnitCar("Model", 5, 0);
            UnitDriver driver = new UnitDriver("Pesho", testCar);
            UnitDriver driver2 = new UnitDriver("Gosho", testCar);
            UnitDriver driver3 = new UnitDriver("Stasi", testCar);
            race.AddDriver(driver);
            race.AddDriver(driver2);
            race.AddDriver(driver3);

            Assert.That(race.CalculateAverageHorsePower(), Is.EqualTo(5));

        }
    }
}