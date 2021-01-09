using System;

namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int count = 0;
            double tempPower = pokePower * 0.5;
            while (pokePower >= distance)
            {
                count++;
                pokePower -= distance;
                if (pokePower == tempPower && exhaustionFactor != 0)
                {
                    pokePower /= exhaustionFactor;
                }
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(count);
            
        }
    }
}
