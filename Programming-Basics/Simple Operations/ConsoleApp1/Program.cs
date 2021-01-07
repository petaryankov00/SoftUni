using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int a = int.Parse(Console.ReadLine());
            
            int b = int.Parse(Console.ReadLine());
            double price = a * 2.5;
            double price1 = b * 4;
            Console.WriteLine($"{price + price1:F2} lv.");
        }
    }
}
