using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, double>> plants = new Dictionary<string, Dictionary<string,double>>();
            Dictionary<string, List<int>> ratings = new Dictionary<string, List<int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int rarity = int.Parse(input[1]);
                if (!plants.ContainsKey(name))
                {
                    plants.Add(name, new Dictionary<string, double>
                   {
                       {"rarity",0},
                       {"averageRating",0}
                   });                  
                }
                plants[name]["rarity"] += rarity;
                
            }
            string command = Console.ReadLine();
            
            while (command != "Exhibition")
            {
                string[] cmdArgs = command.Split(new string[] {" - ",": "},StringSplitOptions.RemoveEmptyEntries);
                string name = cmdArgs[1];
                if (cmdArgs[0] == "Rate")
                {
                    int rating = int.Parse(cmdArgs[2]);
                    if (plants.ContainsKey(name) && rating >=0)
                    {
                        if (ratings.ContainsKey(name))
                        {
                            ratings[name].Add(rating);
                        }
                        else
                        {
                            ratings.Add(name, new List<int> { rating });
                        }                             
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (cmdArgs[0] == "Update")
                {
                    int newRarity = int.Parse(cmdArgs[2]);
                    if (plants.ContainsKey(name) && newRarity >=0)
                    {
                        plants[name]["rarity"] = newRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (cmdArgs[0] == "Reset")
                {
                    if (plants.ContainsKey(name))
                    {
                        for (int i = 0; i < ratings[name].Count; i++)
                        {
                            ratings[name][i] = 0;
                        }
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                command = Console.ReadLine();
            }           
            foreach (var item in ratings)
            {
                double sum = 0;
                for (int i = 0; i < item.Value.Count; i++)
                {
                    sum += item.Value[i];
                }
                double average = sum / item.Value.Count;
                plants[item.Key]["averageRating"] = average;
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var currPlant in plants.OrderByDescending(x=>x.Value["rarity"]).ThenByDescending(a=>a.Value["averageRating"]))
            {             
                Console.WriteLine($"- {currPlant.Key}; Rarity: {currPlant.Value["rarity"]}; Rating: {currPlant.Value["averageRating"]:f2}");
            }
        }
    }
}
