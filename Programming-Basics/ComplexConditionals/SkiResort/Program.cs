using System;

namespace SkiResort
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberDays = int.Parse(Console.ReadLine());
            string typeRoom = Console.ReadLine();
            string grade = Console.ReadLine();

            int numberNights = numberDays - 1;
            double sumNights = 0;

            if (typeRoom == "room for one person")
            {
                sumNights = numberNights * 18;         
            }

            if (typeRoom == "apartment")
            {
                sumNights = numberNights * 25;
                if (numberDays < 10)
                {
                    sumNights = sumNights * 0.7;
                }
                else if (numberDays > 15)
                {
                    sumNights = sumNights * 0.5;
                }
                else
                {
                    sumNights = sumNights * 0.65;
                }
            }

            if (typeRoom == "president apartment")
            {
                sumNights = numberNights * 35;
                if (numberDays < 10)
                {
                    sumNights = sumNights * 0.9;
                }
                else if (numberDays > 15)
                {
                    sumNights = sumNights* 0.8;
                }
                else
                {
                    sumNights = sumNights * 0.85;
                }
            }
            if (grade == "positive")
            {
                sumNights = sumNights * 1.25;
            }
            else if (grade == "negative")
            {
                sumNights = sumNights * 0.9;
            }
            Console.WriteLine($"{sumNights:F2}");


        }
    }
}
