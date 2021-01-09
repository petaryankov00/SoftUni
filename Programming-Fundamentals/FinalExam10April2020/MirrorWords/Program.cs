using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(#|@)(?<first>[A-Za-z]{3,})\1\1(?<second>[A-Za-z]{3,})\1";
            List<string> pairs = new List<string>();
            MatchCollection words = Regex.Matches(input, pattern);
            if (words.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                return;
            }
            else
            {
                Console.WriteLine($"{words.Count} word pairs found!");
            }
            foreach (Match pair in words)
            {
                string firstWord = pair.Groups["first"].ToString();
                string secondWord = pair.Groups["second"].ToString();
                char[] arr = secondWord.ToCharArray();
                Array.Reverse(arr);
                string reversedWord = String.Join("", arr);
                if (firstWord == reversedWord)
                {
                    string mirrorWord = firstWord + " <=> " + secondWord;
                    pairs.Add(mirrorWord);
                }
            }
            if (pairs.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ",pairs));
            }
            
        }
    }
}
