using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MaxAndMinElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] cmdArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (cmdArgs[0] == 1)
                {
                    numbers.Push(cmdArgs[1]);
                }
                else if (cmdArgs[0] == 2)
                {
                    if (numbers.Any())
                    {
                        numbers.Pop();
                    }                 
                }
                else if (cmdArgs[0] == 3)
                {
                    if (numbers.Any())
                    {
                        Console.WriteLine(numbers.Max());
                    }
                   
                }
                else if (cmdArgs[0] == 4)
                {
                    if (numbers.Any())
                    {
                        Console.WriteLine(numbers.Min());
                    }
                }
            }
            if (numbers.Any())
            {
                Console.WriteLine(string.Join(", ", numbers));
            }          
        }
    }
}
