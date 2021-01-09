using System;

namespace TextProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            string result = string.Empty;
            foreach (var word in input)
            {
                int length = word.Length;

                for (int i = 0; i < length; i++)
                {
                    result += word;
                }
            }
            Console.WriteLine(result);
        }
    }
}
