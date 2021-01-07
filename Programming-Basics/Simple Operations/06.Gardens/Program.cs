using System;

namespace _06.Gardens
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double price = a * 7.61;
            double dcount = price * 0.18;
            double fprice = price - dcount;
            Console.WriteLine($"The final price is: {fprice:F2} lv.");
            Console.WriteLine($"The discount is: {dcount:F2} lv.");
        }
    }
}
