using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            string city = Console.ReadLine();
            double sellsCount = double.Parse(Console.ReadLine());
            double price = 0;

            if (city == "Sofia")
            {
                if (sellsCount >= 0 && sellsCount <= 500)
                {
                    price = sellsCount * 0.05;
                    Console.WriteLine($"{price:F2}");
                }
                else if (sellsCount > 500 && sellsCount <= 1000)
                {
                    price = sellsCount * 0.07;
                    Console.WriteLine($"{price:F2}");
                }
                else if (sellsCount > 1000 && sellsCount <= 10000)
                {
                    price = sellsCount * 0.08;
                    Console.WriteLine($"{price:F2}");
                }
                else if (sellsCount > 10000)
                {
                    price = sellsCount * 0.12;
                    Console.WriteLine($"{price:F2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "Varna")
            {
                if (sellsCount >= 0 && sellsCount <= 500)
                {
                    price = sellsCount * 0.045;
                    Console.WriteLine($"{price:F2}");
                }
                else if (sellsCount > 500 && sellsCount <= 1000)
                {
                    price = sellsCount * 0.075;
                    Console.WriteLine($"{price:F2}");
                }
                else if (sellsCount > 1000 && sellsCount <= 10000)
                {
                    price = sellsCount * 0.10;
                    Console.WriteLine($"{price:F2}");
                }
                else if (sellsCount > 10000)
                {
                    price = sellsCount * 0.13;
                    Console.WriteLine($"{price:F2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "Plovdiv")
            {
                if (sellsCount >= 0 && sellsCount <= 500)
                {
                    price = sellsCount * 0.055;
                    Console.WriteLine($"{price:F2}");
                }
                else if (sellsCount > 500 && sellsCount <= 1000)
                {
                    price = sellsCount * 0.08;
                    Console.WriteLine($"{price:F2}");
                }
                else if (sellsCount > 1000 && sellsCount <= 10000)
                {
                    price = sellsCount * 0.12;
                    Console.WriteLine($"{price:F2}");
                }
                else if (sellsCount > 10000)
                {
                    price = sellsCount * 0.145;
                    Console.WriteLine($"{price:F2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else 
            {
                Console.WriteLine("error");
            }
            
        }
    }
}
