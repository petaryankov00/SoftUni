using System;

namespace PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintTriangle(n);
        }
        static void SingleLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        static void PrintTriangle(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                SingleLine(1, i);
            }
            for (int i = n-1; i >= 1; i--)
            {
                SingleLine(1, i);
            }
        }
    }
}
