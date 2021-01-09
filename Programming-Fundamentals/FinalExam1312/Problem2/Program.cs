using System;
using System.Text.RegularExpressions;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"(?:(\*|@)([A-Z][a-z]{2,})\1: \[([A-Za-z])\]\|\[([A-Za-z])\]\|\[([A-Za-z])\]\|)$";
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match regex = Regex.Match(input, pattern);
                if (regex.Success)
                {
                    char firstLetter = char.Parse(regex.Groups[3].Value);
                    char secondLetter = char.Parse(regex.Groups[4].Value);
                    char thirdLetter = char.Parse(regex.Groups[5].Value);
                    int firstAscii = (int)(firstLetter);
                    int secondAscii = (int)(secondLetter);
                    int thirdAscii = (int)(thirdLetter);
                    Console.WriteLine($"{regex.Groups[2].Value}: {firstAscii} {secondAscii} {thirdAscii}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
