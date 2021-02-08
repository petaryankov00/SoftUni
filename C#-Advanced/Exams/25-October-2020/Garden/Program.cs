using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int[,] garden = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    garden[row, col] = 0;
                }
            }

            string flower = Console.ReadLine();


            while (flower != "Bloom Bloom Plow")
            {
                int[] flowerIndexes = flower.Split().Select(int.Parse).ToArray();
                int flowerRow = flowerIndexes[0];
                int flowerCol = flowerIndexes[1];
                if (isValid(flowerRow, flowerCol, garden))
                {
                    garden = BloomBloomPow(flowerRow, flowerCol, rows, cols, garden);
                }
                else
                {
                    Console.WriteLine("Invalid cordinates.");
                }

                flower = Console.ReadLine();
            }



            PrintGarden(garden);
        }

        private static void PrintGarden(int[,] garden)
        {
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    Console.Write(garden[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int[,] BloomBloomPow(int flowerRow, int flowerCol, int rows, int cols, int[,] garden)
        {
            garden[flowerRow, flowerCol] = -1;
            for (int i = 0; i < rows; i++)
            {
                garden[i, flowerCol]++;
            }

            for (int i = 0; i < cols; i++)
            {
                garden[flowerRow, i]++;
            }

            return garden;

        }

        private static bool isValid(int flowerRow, int flowerCol, int[,] garden)
        {
            return flowerRow >= 0 && flowerRow < garden.GetLength(0)
                && flowerCol >= 0 && flowerCol < garden.GetLength(1);
        }
    }
}
