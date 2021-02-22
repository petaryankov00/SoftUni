using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Racer racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racerToRemove = data.FirstOrDefault(x => x.Name == name);
            if (racerToRemove == null)
            {
                return false;
            }
            data.Remove(racerToRemove);
            return true;
        }

        public Racer GetOldestRacer()
        {
            Racer oldestRacer = data.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestRacer;
        }

        public Racer GetRacer(string name)
        {
            Racer lookingRacer = data.FirstOrDefault(x => x.Name == name);
            if (lookingRacer == null)
            {
                return null;
            }
            return lookingRacer;
        }

        public Racer GetFastestRacer()
        {
            Racer fastestRacer = data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
            return fastestRacer;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach (var racer in data)
            {
                sb.AppendLine($"{racer}");
            }
            string report = sb.ToString().Trim();
            return report;
        }
    }
}
