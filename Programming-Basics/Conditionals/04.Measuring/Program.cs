using System;

namespace _04.Measuring
{
    class Program
    {
        static void Main(string[] args)
        {
            double startNumber = double.Parse(Console.ReadLine());
            string startM = Console.ReadLine();
            string endM = Console.ReadLine();
            double finalNumber = startNumber;
            if (startM == "mm")
            {
                finalNumber = startNumber / 10;
            }
            else if (startM == "m")
            {
                finalNumber = startNumber * 100;
            }
            else if (startM == "cm") 
            {
                finalNumber = startNumber;
            }
            if (endM == "mm")
            {
                finalNumber = finalNumber*10 ;
            }
            else if (endM == "m")
            {
                finalNumber = finalNumber / 100;
            }
            else if (endM == "cm")
            {
                finalNumber = finalNumber*1;
            }
            Console.WriteLine($"{finalNumber:F3}");
        }
    }
}
