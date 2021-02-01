using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string,int>> wardrobe = new Dictionary<string, Dictionary<string,int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string colour = input[0];
                string[] clothes = input[1].Split(",");
                if (!wardrobe.ContainsKey(colour))
                {
                    wardrobe.Add(colour, new Dictionary<string, int>());
                }
                foreach (var clothe in clothes)
                {
                    if (!wardrobe[colour].ContainsKey(clothe))
                    {
                        wardrobe[colour].Add(clothe, 0);
                    }
                    wardrobe[colour][clothe]++;
                }
            }

            string[] searchedPair = Console.ReadLine().Split();
            string searchedColor = searchedPair[0];
            string searchedClothe = searchedPair[1];

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var currClothe in item.Value)
                {
                    if (item.Key == searchedColor && currClothe.Key == searchedClothe)
                    {
                        Console.WriteLine($"* {currClothe.Key} - {currClothe.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {currClothe.Key} - {currClothe.Value}");
                    }
                }
            }
        }
    }
}
