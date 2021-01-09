using System;
using System.Text.RegularExpressions;

namespace RegularExpressionExc2711
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([A-Za-z]+)<<(\d+\.?\d*)!(\d+)";
            var regex = new Regex(pattern);

            double totalMoneySpend = 0;

            string input = Console.ReadLine();
            Console.WriteLine("Bought furniture:");

            while (input != "Purchase")
            {
                Match match = regex.Match(input);
                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    double price = double.Parse(match.Groups[2].Value);
                    double quantity = double.Parse(match.Groups[3].Value);

                    Console.WriteLine(name);
                    totalMoneySpend += price * quantity;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Total money spend: {totalMoneySpend:f2}");
        }
    }
}
