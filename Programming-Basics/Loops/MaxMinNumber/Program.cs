using System;

namespace MaxMinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int maxValue = int.MinValue;
            int minValue = int.MaxValue;
            for (int i = 1; i <= input ; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (currentNumber < minValue)
                {
                    minValue = currentNumber;
                }
                if (currentNumber > maxValue)
                {
                    maxValue = currentNumber;
                }
            }
            Console.WriteLine($"Max number: {maxValue}");
            Console.WriteLine($"Min number: {minValue}");


        }
    }
}
