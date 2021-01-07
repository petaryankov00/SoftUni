using System;

namespace HoneyHarvest
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int countFlowers = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double honey = 0;
            double sumHoney = 0;
            if (season == "Spring")
            {
                if (flowerType == "Sunflower")
                {
                    honey = 10;
                    sumHoney = honey * countFlowers;
                }
                else if (flowerType == "Daisy")
                {
                    honey = 12;
                    sumHoney = honey * countFlowers * 1.10;
                }
                else if (flowerType == "Lavender")
                {
                    honey = 12;
                    sumHoney = honey * countFlowers;
                }
                else if (flowerType == "Mint")
                {
                    honey = 10;
                    sumHoney = honey * countFlowers * 1.10;
                }
            }

            if (season == "Summer")
            {
                if (flowerType == "Sunflower")
                {
                    honey = 8;
                    sumHoney = honey * countFlowers * 1.10;
                }
                else if (flowerType == "Daisy")
                {
                    honey = 8;
                    sumHoney = honey * countFlowers * 1.10;
                }
                else if (flowerType == "Lavender")
                {
                    honey = 8;
                    sumHoney = honey * countFlowers * 1.10;
                }
                else if (flowerType == "Mint")
                {
                    honey = 12;
                    sumHoney = honey * countFlowers * 1.10;
                }
            }

            if (season == "Autumn")
            {
                if (flowerType == "Sunflower")
                {
                    honey = 12;
                    sumHoney = honey * countFlowers * 0.95;
                }
                else if (flowerType == "Daisy")
                {
                    honey = 6;
                    sumHoney = honey * countFlowers * 0.95;
                }
                else if (flowerType == "Lavender")
                {
                    honey = 6;
                    sumHoney = honey * countFlowers * 0.95;
                }
                else if (flowerType == "Mint")
                {
                    honey = 6;
                    sumHoney = honey * countFlowers * 0.95;
                }
            }
            Console.WriteLine($"Total honey harvested: {sumHoney:f2}");
        }
    }
}

