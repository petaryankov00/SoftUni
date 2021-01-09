using System;
using System.Linq;

namespace CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split(" ").ToArray();
            string[] secondArray = Console.ReadLine().Split(" ").ToArray();
            foreach (string elemntTwo in secondArray)
            {
                for (int i = 0; i < firstArray.Length; i++)
                {
                    if (elemntTwo == firstArray[i])
                    {
                        Console.Write($"{elemntTwo} ");
                        break;
                    }
                }
            }

        }
    }
}
