using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            
            while (destination != "End")
            {
                double budget = double.Parse(Console.ReadLine());
                double savedMoney = double.Parse(Console.ReadLine());
                double sum = savedMoney;
                while (sum < budget)
                {
                    savedMoney = double.Parse(Console.ReadLine());
                    sum += savedMoney;
                    
                }
                Console.WriteLine($"Going to {destination}!");
                destination = Console.ReadLine();
            }
        }
    }
}
