using System;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            double sumNumbers = 0;
            while (input != "Stop")
            {
                sumNumbers += double.Parse(input);
                input = Console.ReadLine();
            }
            Console.WriteLine(sumNumbers);
        }
    }
}
