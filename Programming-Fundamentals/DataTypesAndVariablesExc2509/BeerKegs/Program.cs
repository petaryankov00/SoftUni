using System;

namespace BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            //π * r^2 * h.
            int n = int.Parse(Console.ReadLine());
            string biggestKeg = string.Empty;
            double biggestVolume = 0;

            for (int i = 0; i < n; i++)
            {
                string currentKeg = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int heigh = int.Parse(Console.ReadLine());
                double volume = Math.PI * Math.Pow(radius, 2) * heigh;

                if (volume > biggestVolume)
                {
                    biggestKeg = currentKeg;
                    biggestVolume = volume;
                }
            }
            Console.WriteLine(biggestKeg);
        }
    }
}
