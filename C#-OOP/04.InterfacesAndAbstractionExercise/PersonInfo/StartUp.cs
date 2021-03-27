
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] parts = line.Split();

                if (parts[0] == "Citizen")
                {
                    string name = parts[1];
                    int age = int.Parse(parts[2]);
                    string id = parts[3];
                    string birthdate = parts[4];
                    birthables.Add(new Citizen(name, age, id, birthdate));
                }
                else if (parts[0] == "Pet")
                {
                    string name = parts[1];
                    string birthdate = parts[2];
                    birthables.Add(new Pet(name, birthdate));
                }

                line = Console.ReadLine();
            }

            string year = Console.ReadLine();
            var output = birthables.Where(x => x.Birthdate.EndsWith(year)).ToList();

            if (output.Any())
            {
                foreach (var item in output)
                {
                    Console.WriteLine(item.Birthdate);
                }
            }
        }
    }
}
