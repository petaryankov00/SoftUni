using System;
using System.Diagnostics.CodeAnalysis;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[n][];

            for (int row = 0; row < n; row++)
            {
                jaggedArray[row] = new long[row + 1];

                for (int col = 0; col < row+1; col++)
                {
                    long currElement = 0;
                    if (row - 1 >= 0 && col < jaggedArray[row-1].Length)
                    {
                        currElement += jaggedArray[row - 1][col];
                    }
                    if (row - 1 >= 0 && col - 1 >= 0)
                    {
                        currElement += jaggedArray[row - 1][col - 1];
                    }
                    if (currElement == 0)
                    {
                        currElement = 1;
                    }
                    jaggedArray[row][col] = currElement;
                }
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
