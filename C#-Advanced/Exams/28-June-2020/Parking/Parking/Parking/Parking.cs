using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Parking
{
    class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (carToRemove == null)
            {
                return false;
            }
            else
            {
                data.Remove(carToRemove);
                return true;
            }
        }

        public Car GetLatestCar()
        {
            Car latestCar = data.OrderByDescending(x => x.Year).FirstOrDefault();
            if (latestCar == null)
            {
                return null;
            }
            else
            {
                return latestCar;
            }
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car car = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (car == null)
            {
                return null;
            }
            else
            {
                return car;
            }
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in data)
            {
                sb.AppendLine($"{car}");
            }
            string statistics = sb.ToString().Trim();
            return statistics;
        }
    }
}
