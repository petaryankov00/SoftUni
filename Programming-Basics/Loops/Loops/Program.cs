using System;
using System.Diagnostics.CodeAnalysis;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int Leftsum = 0;
            for (int i = 1; i <= input; i++)
            {
                int n = int.Parse(Console.ReadLine());
                Leftsum += n;
            }
            int RightSum = 0;
            for (int i = 1; i <= input ; i++)
            {
                int n = int.Parse(Console.ReadLine());
                RightSum += n;
            }
            if (Leftsum == RightSum)
            {
                Console.WriteLine($"Yes, sum = {Leftsum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(Leftsum-RightSum)}");
            }

            
           
            
            
        }
    }
}
