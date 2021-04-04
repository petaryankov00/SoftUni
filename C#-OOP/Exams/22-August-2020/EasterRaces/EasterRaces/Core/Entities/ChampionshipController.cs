using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository carRepository;
        private DriverRepository driverRepository;
        private RaceRepository raceRepository;

        public ChampionshipController()
        {
            carRepository = new CarRepository();
            driverRepository = new DriverRepository();
            raceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = driverRepository.GetAll().FirstOrDefault(x => x.Name == driverName);
            var car = carRepository.GetAll().FirstOrDefault(x => x.Model == carModel);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var driver = driverRepository.GetAll().FirstOrDefault(x => x.Name == driverName);
            var race = raceRepository.GetAll().FirstOrDefault(x => x.Name == raceName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            race.AddDriver(driver);

            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            var carToFind = carRepository.GetAll().FirstOrDefault(x => x.Model == model
            && x.HorsePower == horsePower);
            if (carToFind != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }
            carRepository.Add(car);

            return $"{car.GetType().Name} {model} is created.";

        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);
            var findDriver = driverRepository.GetAll().FirstOrDefault(x => x.Name == driverName);
            if (findDriver != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            driverRepository.Add(driver);
            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            var race = raceRepository.GetAll().FirstOrDefault(x => x.Name == name);
            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }
            race = new Race(name, laps);
            raceRepository.Add(race);

            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.GetAll().FirstOrDefault(x => x.Name == raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            foreach (var driver in race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)))
            {
                if (counter == 3)
                {
                    break;
                }

                if (counter == 0)
                {
                    sb.AppendLine($"Driver {driver.Name} wins {race.Name} race.");
                }
                else if (counter == 1)
                {
                    sb.AppendLine($"Driver {driver.Name} is second in {race.Name} race.");
                }
                else if (counter == 2)
                {
                    sb.AppendLine($"Driver {driver.Name} is third in {race.Name} race.");
                }
                counter++;
            }

            raceRepository.Remove(race);

            return sb.ToString().Trim();
        }

    }

}

