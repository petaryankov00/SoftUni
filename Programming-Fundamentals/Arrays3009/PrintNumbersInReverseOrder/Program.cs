using System;
using System.Linq;

namespace PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            //string line = Console.ReadLine();  
            //string[] textarr = line.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            //int[] arr = textarr.Select(int.Parse).ToArray();
            int[] arr = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();
            //string[] line = Console.ReadLine().Split().ToArray();
       
        }
    }
}
