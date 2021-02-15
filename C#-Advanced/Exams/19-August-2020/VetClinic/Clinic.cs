using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Pet pet)
        {
            if (data.Count < this.Capacity)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet removePet = data.FirstOrDefault(x => x.Name == name);
            if (removePet == null)
            {
                return false;                
            }
            else
            {
                data.Remove(removePet);
                return true;
            }
        }

        public Pet GetPet(string name, string owner)
        {
            Pet lookingPet = data.FirstOrDefault(x => x.Name == name && x.Owner == owner);
            if (lookingPet == null)
            {
                return null;
            }
            else
            {
                return lookingPet;
            }
        }

        public Pet GetOldestPet()
        {
            return data.OrderByDescending(p => p.Age).FirstOrDefault();
        }


        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            string statistics = sb.ToString().Trim();
            return statistics;
        }

    }
    
}
