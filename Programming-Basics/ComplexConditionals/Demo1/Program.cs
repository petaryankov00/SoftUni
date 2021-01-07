using System;

namespace Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string campOrHotel = "";
            double price = 0;
            string place = "";
            

            if (budget <= 100)
            {
                place = "Bulgaria";
                if (season == "summer")
                {
                    campOrHotel = "Camp";
                    price = budget * 0.3;
                }
                else if (season == "winter")
                {
                    campOrHotel = "Hotel";
                    price = budget * 0.7;
                }

            }
            else if (budget <=1000)
            {
                place = "Balkans";
                if (season == "summer")
                {
                    campOrHotel = "Camp";
                    price = budget * 0.4;
                }
                else if (season == "winter")
                {
                    campOrHotel = "Hotel";
                    price = budget * 0.8;
                }
            }
            else if (budget > 1000)
            {
                place = "Europe";
                price = budget * 0.9;
                campOrHotel = "Hotel";
            }

            Console.WriteLine($"Somewhere in {place}");
            Console.WriteLine($"{campOrHotel} - {price:F2}");
             
        }
    }
}
