using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(", ").ToList();
            Dictionary<string, int> namesOfPeople = new Dictionary<string, int>();

            foreach (var name in input)
            {
                namesOfPeople.Add(name, 0);
            }
            string namePattern = @"[\W\d]";
            string numberPattern = @"[\WA-Za-z]";

            string cmd = Console.ReadLine();
            while (cmd != "end of race")
            {
                string name = Regex.Replace(cmd, namePattern, "");
                string distance = Regex.Replace(cmd, numberPattern, "");
                int sum = 0;

                foreach (var digit in distance)
                {
                    int currDigit = int.Parse(digit.ToString());
                    sum += currDigit;
                }
                if (namesOfPeople.ContainsKey(name))
                {
                    namesOfPeople[name] += sum;
                }
                cmd = Console.ReadLine();
            }
            int count = 1;
            foreach (var kvp in namesOfPeople.OrderByDescending(x=>x.Value))
            {
                string output = string.Empty;
                if (count == 1)
                {
                    output = "st";
                }
                else if (count == 2)
                {
                    output = "nd";
                }
                else if (count == 3)
                {
                    output = "rd";
                }
                Console.WriteLine($"{count++}{output} place: {kvp.Key}");

                if (count == 4)
                {
                    break;
                }
            }
        }
    }
}
