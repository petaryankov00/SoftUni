using System;
using System.Linq;

namespace EvenAndOddSub
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                           .Split()
                           .Select(int.Parse)
                           .ToArray();
            int sumEven = 0;
            int sumOdd = 0;
            foreach (var item in numbers)
            {
                if (item % 2 == 0)
                {
                    sumEven += item;
                }
                else
                {
                    sumOdd += item;
                }
            }
            Console.WriteLine($"{sumEven - sumOdd}");
        }
    }
}
