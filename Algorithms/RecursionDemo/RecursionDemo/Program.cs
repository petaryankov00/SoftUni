using System;

namespace RecursionDemo
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Fibonacci(n));

            int previousNumber = 0;
            int currentNumber = 1;

            //Fibonacci iterative
            for (int i = 1; i < n; i++)
            {
                int temp = previousNumber;
                previousNumber = currentNumber;
                currentNumber = temp + currentNumber;
            }
            Console.WriteLine(currentNumber);


            Console.WriteLine(Factorial(n));
        }

        public static int Fibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1 || n == 2)
            {
                return 1;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public static int Factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
