using System;
using System.Linq;

namespace CaeserChipest
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string output = String.Empty;
            foreach (var currChar in input)
            {
                var newChar = (char)(currChar + 3);
                output += newChar;
            }
            Console.WriteLine(output);
        }
    }
}
