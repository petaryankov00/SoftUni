using System;

namespace TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupsCount = int.Parse(Console.ReadLine());
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            int count5 = 0;



            for (int i = 1; i <= groupsCount; i++)
            {
                int peopleCount = int.Parse(Console.ReadLine());
                if (peopleCount <= 5)
                {
                    count1 += peopleCount;
                }
                else if (peopleCount <= 12)
                {
                    count2 += peopleCount;
                }
                else if (peopleCount <= 25)
                {
                    count3 += peopleCount;
                }
                else if (peopleCount <= 40)
                {
                    count4 += peopleCount;
                }
                else if (peopleCount >= 41)
                {
                    count5 += peopleCount;
                }
            }
            double allPeople = count1 + count2 + count3 + count4 + count5;
            double percentMusala = (count1 / allPeople) * 100;
            double percentMonbolan = (count2 / allPeople) * 100;
            double percentKilim = (count3 / allPeople) * 100;
            double percentK2 = (count4 / allPeople) * 100;
            double percentEverest = (count5 / allPeople) * 100;

            Console.WriteLine($"{percentMusala:F2}%");
            Console.WriteLine($"{percentMonbolan:F2}%");
            Console.WriteLine($"{percentKilim:F2}%");
            Console.WriteLine($"{percentK2:F2}%");
            Console.WriteLine($"{percentEverest:F2}%");


        }
    }
}
