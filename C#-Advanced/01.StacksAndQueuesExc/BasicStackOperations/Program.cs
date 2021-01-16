using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();           
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>();
            int n = data[0]; 
            int s = data[1];
            int x = data[2];

            for (int i = 0; i < n; i++)
            {
                numbers.Push(inputNumbers[i]);
            }
            for (int i = 0; i < s; i++)
            {
                numbers.Pop();
            }

            if (numbers.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (numbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(numbers.Min()); 
            }
        }
    }
}
