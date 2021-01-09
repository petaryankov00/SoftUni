using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            for (int i = m; i <= 10; i++)
            {
                Console.WriteLine($"{n} X {i} = {n*i}");
            }
            if (m > 10)
            {
                Console.WriteLine($"{n} X {m} = {n*m}");
            }
        }
    }
}
