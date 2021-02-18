using System;
using System.Linq;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
                      
            PrintSumAndCount(
                int.Parse,
                a => a.Length,
                array => array.Sum()
                );
        }

        static void PrintSumAndCount(Func<string,int> parser,
            Func<int[],int> countGetter,
            Func<int[],int> sumCalculator )
        {
            int[] array = Console.ReadLine()
                .Split(", ")
                .Select(parser)
                .ToArray();
            Console.WriteLine(countGetter(array));
            Console.WriteLine(sumCalculator(array));
              
        }
    }
}
