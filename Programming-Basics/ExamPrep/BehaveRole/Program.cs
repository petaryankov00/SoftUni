using System;

namespace BehaveRole
{
    class Program
    {
        static void Main(string[] args)
        {
            double inteligence = double.Parse(Console.ReadLine());
            double strength = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            if (inteligence >= 80 && strength >=80 && gender == "female")
            {
                Console.WriteLine("Queen Bee");
            }
            else if (inteligence >=80)
            {
                Console.WriteLine("Repairing Bee");
            }
           else if (inteligence >= 60)
            {
                Console.WriteLine("Cleaning Bee");
            }
            else if (strength >=80 && gender == "male")
            {
                Console.WriteLine("Drone Bee");
            }
            else if (strength >= 60)
            {
                Console.WriteLine("Guard Bee");
            }
            else
            {
                Console.WriteLine("Worker Bee");
            }
        }
    }
}
