using System;

namespace SumOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <=n ; i++)
            {
                int oddNumbers = i * 2 - 1;
                Console.WriteLine(oddNumbers);
                sum += oddNumbers;
            }
            Console.WriteLine($"Sum: {sum}");

        }
    }
}
