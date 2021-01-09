using System;

namespace Arrays3009
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days = new string[]
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            int dayNum = int.Parse(Console.ReadLine());

            if (dayNum < 1 || dayNum > days.Length)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(days[dayNum-1]);
            }
        }
    }
}
