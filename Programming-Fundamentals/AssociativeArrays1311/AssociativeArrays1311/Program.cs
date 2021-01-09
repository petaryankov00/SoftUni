using System;
using System.Collections.Generic;
using System.Linq;

namespace AssociativeArrays1311
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Dictionary<char, int> letters = new Dictionary<char, int>();
            foreach (var letter in input)
            {
                if (letter != ' ')
                {
                    if (!letters.ContainsKey(letter))
                    {
                        letters.Add(letter,0);
                    }
                    letters[letter]++;
                }
            }
            foreach (var c in letters)
            {
                Console.WriteLine($"{c.Key} -> {c.Value}");
            }
        }
    }
}
