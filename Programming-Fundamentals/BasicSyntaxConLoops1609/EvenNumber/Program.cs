using System;

namespace EvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            while (Math.Abs(n % 2) != 0)
            {
                Console.WriteLine("Please write an even number.");
                n = int.Parse(Console.ReadLine());
            }
            if (Math.Abs(n % 2) == 0)
            {
                Console.WriteLine($"The number is: {Math.Abs(n)}");
            }
        }
    }
}
