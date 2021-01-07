using System;

namespace Suitcases
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());
            string suitcase = Console.ReadLine();
            int counter = 0;
            while (suitcase != "End")
            {                            
                if ((counter+1) % 3 == 0)
                {
                    double suitcase3 = double.Parse(suitcase);
                    suitcase3 = suitcase3 * 1.1;
                    capacity -= suitcase3;
                }
                else
                {
                    capacity -= double.Parse(suitcase);
                }
                if (capacity < 0)
                {
                    break;
                }
                counter++;
                suitcase = Console.ReadLine();
            }
            if (capacity < 0)
            {
                Console.WriteLine("No more space!");
                Console.WriteLine($"Statistic: {counter} suitcases loaded.");
            }
            else
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
                Console.WriteLine($"Statistic: {counter} suitcases loaded.");
            }
        }
    }
}
