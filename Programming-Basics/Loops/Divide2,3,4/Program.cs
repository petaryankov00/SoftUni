using System;

namespace Divide2_3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            double count1 = 0;
            double count2 = 0;
            double count3 = 0;
            for (int i = 1; i <= input; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number % 2 == 0)
                {
                    count1++;
                }
                if (number % 3 == 0)
                {
                    count2++;
                }
                if (number % 4 == 0)
                {
                    count3++;
                }
            }
            double p1 = count1 / input * 100;
            double p2 = count2 / input * 100;
            double p3 = count3 / input * 100;
            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");

        }
    }
}
