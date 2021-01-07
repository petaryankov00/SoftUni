using System;

namespace ExamTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double apartMoney = 0;
            double studioMoney = 0;

            if (month == "May" || month == "October")
            {
                apartMoney = nights * 65;
                studioMoney = nights * 50;
            }
            else if (month == "June" || month == "September")
            {
                apartMoney = nights * 68.70;
                studioMoney = nights * 75.20;
            }
            else if (month == "July" || month == "August")
            {
                apartMoney = nights * 77;
                studioMoney = nights * 76;
            }
            if (nights > 7 && nights < 14 && (month == "May" || month == "October"))
            {
                studioMoney = studioMoney * 0.95;
            }
            else if (nights > 14 && (month == "May" || month == "October"))
            {
                studioMoney = studioMoney * 0.7;
            }
            else if (nights > 14 && (month == "June" || month == "September"))
            {
                studioMoney = studioMoney * 0.8;
            }
            if (nights > 14)
            {
                apartMoney = apartMoney * 0.9;
            }
            Console.WriteLine($"Apartment: {apartMoney:F2} lv.");
            Console.WriteLine($"Studio: {studioMoney:F2} lv.");
        }
    }
}
