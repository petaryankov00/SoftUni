using System;
using System.Linq;

namespace TextProcessingExc
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                var currName = input[i];
                if (isValid(currName))
                {
                    Console.WriteLine(currName);
                }

            }
        }
        public static bool isValid(string currName)
        {
            return currName.Length >= 3 &&
                currName.Length <= 16 &&
                currName.All(c => char.IsLetterOrDigit(c)) ||
                currName.Contains("-") ||
                currName.Contains("_");
        }
    }
}
