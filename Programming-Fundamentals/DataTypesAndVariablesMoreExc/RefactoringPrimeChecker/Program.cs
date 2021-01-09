using System;

namespace RefactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxValue = int.Parse(Console.ReadLine());
            for (int minValue = 2; minValue <= maxValue; minValue++)
            {
                bool isEven = true;
                for (int divider = 2; divider < minValue; divider++)
                {
                    if (minValue % divider == 0)
                    {
                        isEven = false;
                        break;
                    }
                }
                if (isEven)
                {
                    Console.WriteLine($"{minValue} -> true");
                }
                else
                {
                    Console.WriteLine($"{minValue} -> false");
                }
            }

        }
    }
}
