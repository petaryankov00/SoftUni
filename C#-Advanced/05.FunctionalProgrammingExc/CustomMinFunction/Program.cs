using System;
using System.Linq;


namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minFunc = (arr) =>
             {
                 int minValue = int.MaxValue;

                 foreach (int v in arr)
                 {
                     if (v < minValue)
                     {
                         minValue = v;
                     }
                 }
                 return minValue;
             };
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(minFunc(numbers));
        }
    }
}
