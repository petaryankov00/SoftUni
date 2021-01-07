using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int EvenSum = 0;
            int OddSum = 0;
            for (int i = 1; i <= number; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    EvenSum += input;
                }
                else
                {
                    OddSum += input;
                }
            }
            if (EvenSum == OddSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {EvenSum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(EvenSum-OddSum)}");
            }

        }
    }
}
