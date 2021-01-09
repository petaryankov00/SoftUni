using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%([A-Z][a-z]+)%[^|$%\.]*<(\w+)>[^|$%\.]*\|(\d+)\|[^|$%\.]*?(\d+\.?\d*)\$";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            double totalPrice = 0;

            while (input != "end of shift")
            {
                double sum = 0;
                Match match = regex.Match(input);
                if (match.Success)
                {
                    //customer, product, count and a price.
                    string customer = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    int count = int.Parse(match.Groups[3].Value);
                    double price = double.Parse(match.Groups[4].Value);

                    sum = count * price;
                    totalPrice += sum;

                    Console.WriteLine($"{customer}: {product} - {sum:f2}");
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalPrice:f2}");
        }
    }
}
