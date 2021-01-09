using System;

namespace CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());
            ClosestPointToZero(x1, y1, x2, y2); 

        }
        static void ClosestPointToZero(int x1, int y1, int x2, int y2)
        {
            int sum1 = Math.Abs(x1) + Math.Abs(y1);
            int sum2 = Math.Abs(x2) + Math.Abs(y2);
            if (sum1 < sum2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else if (sum1 > sum2)
            {
                Console.WriteLine($"({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x1}, {y1})");
            }
        }
    }
}
