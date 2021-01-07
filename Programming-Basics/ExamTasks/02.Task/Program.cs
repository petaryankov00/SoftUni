using System;

namespace _02.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double strana1 = Math.Abs(x1 - x2);
            double strana2 = Math.Abs(y1 - y2);
            double lice = strana1 * strana2;
            double p = 2 * (strana1 + strana2);
            Console.WriteLine($"{lice:F2}");
            Console.WriteLine($"{p:F2}");


        }
    }
}
