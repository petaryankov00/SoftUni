using System;
using System.Buffers;
using System.Linq;

namespace ZigZagArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] firstArray = new string[n];
            string[] secondArray = new string[n];
            for (int i = 0; i < n; i++)
            {
                string[] currentArray = Console.ReadLine()
                                        .Split(" ")
                                        .ToArray();
                string zeroElement = currentArray[0];
                string firstElement = currentArray[1];
                if (i % 2 == 0)
                {
                    firstArray[i] = zeroElement;
                    secondArray[i] = firstElement;
                }
                if (i % 2 != 0)
                {
                    secondArray[i] = zeroElement;
                    firstArray[i] = firstElement;
                }
            }
            Console.WriteLine(string.Join(" ",firstArray));
            Console.WriteLine(string.Join(" ",secondArray));


        }
    }
}
