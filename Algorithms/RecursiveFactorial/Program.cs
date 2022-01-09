using System;

namespace RecursiveFactorial
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int result = Factorial(n);
            Console.WriteLine(result);
        }

        public static int Factorial(int n)
        {
            if (n == 1)
            {
                return n;
            }

            return n * Factorial(n - 1);
        }
    }
}
