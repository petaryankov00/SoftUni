using System;

namespace WaterOverflaw
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int amountInTank = 0;
            for (int i = 1; i <= n; i++)
            {
                int waterToPour = int.Parse(Console.ReadLine());
                bool isFull = waterToPour > 255;
                bool isOverflaw = amountInTank + waterToPour > 255;
                if (isFull || isOverflaw)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                amountInTank += waterToPour;
            }
            Console.WriteLine(amountInTank);
        }
    }
}
