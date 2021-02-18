using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvenOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boundaries = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string query = Console.ReadLine();
            Predicate<int> predicate = GetPredicate(query);

            List<int> result = new List<int>();

            for (int i = boundaries[0];i<=boundaries[1]; i++)
            {
                if (predicate(i))
                {
                    result.Add(i);         
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }

        private static Predicate<int> GetPredicate(string query)
        {
            if (query == "odd")
            {
                return n => n % 2 != 0;
            }
            else
            {
                return n => n % 2 == 0;
            }
        }
    }
}
