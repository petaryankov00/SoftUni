using System;

namespace ConditionalsAndSimpleOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordTime = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double secFor1Meter = double.Parse(Console.ReadLine());

            double firstSeconds = meters * secFor1Meter;
            double plusSeconds = Math.Floor(meters / 50) * 30;
            double sumSeconds = firstSeconds + plusSeconds;

            if (sumSeconds < recordTime)
            {
                Console.WriteLine($" Yes! The new record is {sumSeconds:F2} seconds.");
            }
            else 
            {
                Console.WriteLine($"No! He was {sumSeconds-recordTime:F2} seconds slower.");
            }



           
            


            
        }
    }
}
