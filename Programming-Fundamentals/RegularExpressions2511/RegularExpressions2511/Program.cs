using System;
using System.Text.RegularExpressions;

namespace RegularExpressions2511
{
    class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();
            string pattern = @"\b[A-Z][a-z]+\b \b[A-Z][a-z]+\b";
            var regex = new Regex(pattern);       
            var matches = regex.Matches(names);

            Console.WriteLine(string.Join(" ",matches));

        }
    }
}
