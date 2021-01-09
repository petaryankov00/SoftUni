using System;
using System.Linq;

namespace Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderByDescending(n => n)
                .ToArray();

            if (arr.Length > 3)
            {
                int[] result = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    result[i] = arr[i];
                }
                Console.WriteLine(string.Join(' ',result));
            }
            else
            {
                Console.WriteLine(string.Join(' ',arr));
            }
        }
    }
}
