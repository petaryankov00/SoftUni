using System;
using System.Text.RegularExpressions;

namespace MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<day>[0-3][0-9])([\.\-\/])(?<month>[A-Z][a-z]{2})\1(?<year>[0-9]{4})\b";
            var regex = new Regex(pattern);
            string dates = Console.ReadLine();
            var matchedDates = regex.Matches(dates);

            foreach (Match match in matchedDates)
            {
                Console.WriteLine($"Day: {match.Groups["day"].Value}, Month: {match.Groups["month"].Value}, Year: {match.Groups["year"].Value}");
            }
        }
    }
}
