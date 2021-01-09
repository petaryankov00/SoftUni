using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(=|\/)([A-Z][A-Za-z]{2,})\1";
            MatchCollection matches = Regex.Matches(input, pattern);
            int travelPoints = 0;
            List<string> destinations = new List<string>();
            foreach (var match in matches) 
            {
                string destination = match.ToString();
                int length = destination.Length - 2;
                travelPoints += length;
                destination = destination.Substring(1, destination.Length - 2);
                destinations.Add(destination);
            }
            Console.WriteLine($"Destinations: {string.Join(", ",destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
