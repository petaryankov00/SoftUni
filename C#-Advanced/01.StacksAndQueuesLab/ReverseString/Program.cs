using System;
using System.Collections;
using System.Collections.Generic;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reversedInput = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                reversedInput.Push(input[i]);
            }
            while (reversedInput.Count > 0)
            {
                Console.Write(reversedInput.Pop());
            }
            Console.WriteLine();

        }
    }
}
