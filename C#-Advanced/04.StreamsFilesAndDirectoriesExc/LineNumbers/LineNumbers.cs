using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            string[] result = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int countOfLetters = CountOfLetters(line);
                int countOfMarks = CountOfPunctuationMarks(line);
                result[i] = $"Line {i + 1}: {line}({countOfLetters})" +
                    $"({countOfMarks})";
            }

            for (int i = 0; i < result.Length; i++)
            {
                File.WriteAllLines("../../../output.txt", result);
            }
        }

        static int CountOfLetters(string line)
        {
            int counter = 0;
            for (int i = 0; i < line.Length; i++)
            {
                char currSymbol = line[i];
                if (Char.IsLetter(currSymbol))
                {
                    counter++;
                }
            }
            return counter;
        }
        static int CountOfPunctuationMarks(string line)
        {
            int counter = 0;
            char[] punctuationMarks ={'-', ',', '.', '!', '?',':',';'};
            for (int i = 0; i < line.Length; i++)
            {
                char currSymbol = line[i];
                if (punctuationMarks.Contains(currSymbol))
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
