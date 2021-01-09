using System;

namespace MidExam0711
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double dailyPlunder = double.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double sumPlunder = 0;

            for (int i = 1; i <= days; i++)
            {
                sumPlunder += dailyPlunder;
                if (i % 3 == 0)
                {
                    double halfDailyPlunder = dailyPlunder*0.5;
                    sumPlunder += halfDailyPlunder;
                }
                if (i % 5 == 0)
                {
                    double minusPlunder = sumPlunder * 0.3;
                    sumPlunder -= minusPlunder;
                }
            }
            if (sumPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {sumPlunder:f2} plunder gained.");
            }
            else
            {
                double percentage = sumPlunder / expectedPlunder;
                double sumPercent = percentage * 100;
                Console.WriteLine($"Collected only {sumPercent:f2}% of the plunder.");
            }
        }
    }
}
