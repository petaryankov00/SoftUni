using System;
using System.Text;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"@\#+([A-Z][A-Za-z0-9]{4,}[A-Z])@\#+";
            string digitPattern = @"\d+";
            Regex regex = new Regex(pattern);
            Regex digitRegex = new Regex(digitPattern);
            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                Match match = regex.Match(barcode);
                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                }
                else
                {                  
                    string newBarcode = match.ToString();
                    MatchCollection digits = digitRegex.Matches(newBarcode);
                    if (digits.Count == 0)
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var digit in digits)
                        {
                            sb.Append(digit);
                        }
                        string productGroup = sb.ToString();
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                }
            }
        }
    }
}
