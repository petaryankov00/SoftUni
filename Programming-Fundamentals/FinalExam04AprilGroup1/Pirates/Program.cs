using System;
using System.Collections.Generic;
using System.Linq;

namespace Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> towns = new Dictionary<string, Dictionary<string, int>>();
            string command = Console.ReadLine();

            while (command != "Sail")
            {
                List<string> cmdArgs = command.Split("||", StringSplitOptions.RemoveEmptyEntries).ToList();
                string name = cmdArgs[0];
                int population = int.Parse(cmdArgs[1]);
                int gold = int.Parse(cmdArgs[2]);
                if (!towns.ContainsKey(name))
                {
                    towns.Add(name, new Dictionary<string, int>()
                    {
                        {"population",population },
                        {"gold",gold }
                    });                                     
                }
                else
                {
                    towns[name]["population"] += population;
                    towns[name]["gold"] += gold;
                }
                command = Console.ReadLine();
            }
            command = Console.ReadLine();

            while (command != "End")
            {
                List<string> cmdArgs = command.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToList();
                string mainCommand = cmdArgs[0];
                if (mainCommand == "Plunder")
                {
                    string name = cmdArgs[1];
                    int population = int.Parse(cmdArgs[2]);
                    int gold = int.Parse(cmdArgs[3]);
                    if (towns.ContainsKey(name))
                    {
                        towns[name]["population"] -= population;
                        towns[name]["gold"] -= gold;
                        Console.WriteLine($"{name} plundered! {gold} gold stolen, {population} citizens killed.");
                        if (towns[name]["population"] <= 0 || towns[name]["gold"] <= 0)
                        {
                            towns.Remove(name);
                            Console.WriteLine($"{name} has been wiped off the map!");
                        }
                    }              
                }
                else if (mainCommand == "Prosper")
                {
                    string name = cmdArgs[1];
                    int gold = int.Parse(cmdArgs[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                        command = Console.ReadLine();
                        continue;
                    }
                    towns[name]["gold"] += gold;
                    Console.WriteLine($"{gold} gold added to the city treasury. {name} now has {towns[name]["gold"]} gold.");
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");
            foreach (var town in towns.OrderByDescending(x => x.Value["gold"]).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{town.Key} -> Population: {town.Value["population"]} citizens, Gold: {town.Value["gold"]} kg");
            }

        }
    }
}
