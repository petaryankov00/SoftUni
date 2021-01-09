using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int number = input;
            int currentNumber = 0;
            int factorialSum = 0;
            while (number != 0)
            {
                currentNumber = number % 10; // take the last number
                number /= 10; // remove the last number
                int factorial = 1;

                for (int i = 1; i <= currentNumber; i++)
                {
                    factorial *= i;
                }
                factorialSum += factorial;
            }
            string result = string.Empty;
            if (input == factorialSum)
            {
                result = "yes";
            }
            else
            {
                result = "no";
            }
            Console.WriteLine(result);
        }
    }
}
