using System;

namespace ComplexConditionalsExcercies
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string smallOrBig = Console.ReadLine();
            int orders = int.Parse(Console.ReadLine());

            double counts = 0;

            if (smallOrBig == "small")
            {
                orders = orders * 2;

                if (fruit == "Watermelon")
                {
                   counts = orders * 56;
                }
                else if (fruit == "Mango")
                {
                    counts = orders * 36.66;
                }
                else if (fruit == "Pineapple")
                {
                    counts = orders * 42.10;
                }
                else if (fruit == "Raspberry")
                {
                    counts = orders * 20;
                }
            }
            if (smallOrBig == "big")
            {
                orders = orders * 5;

                if (fruit == "Watermelon")
                {
                    counts = orders * 28.70;
                }
                else if (fruit == "Mango")
                {
                    counts = orders * 19.60;
                }
                else if (fruit == "Pineapple")
                {
                    counts = orders * 24.80;
                }
                else if (fruit == "Raspberry")
                {
                    counts = orders * 15.20;
                }
            }

            if (counts >= 400 && counts <= 1000)
            {
               counts = counts * 0.85;
            }
            else if (counts > 1000)
            {
                counts = counts * 0.5;
            }
            Console.WriteLine($"{counts:F2} lv.");
        }
    }
}
