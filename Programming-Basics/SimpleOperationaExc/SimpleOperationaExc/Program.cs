using System;

namespace SimpleOperationaExc
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int bakers = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int goff = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double cakePrice = cakes * 45;
            double goffPrice = goff * 5.8;
            double pancakesPrice = pancakes * 3.2;
            double priceForDay = (cakePrice + goffPrice + pancakesPrice) * bakers;
            double sumPrice = priceForDay * days;
            double finalPrice = sumPrice - (sumPrice / 8);
            Console.WriteLine($"{finalPrice:F2}");


 
          
        }
    }
}
