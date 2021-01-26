using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = matrixData[0];
            int m = matrixData[1];

            string[,] matrix = new string[n, m];

            for (int row = 0; row < n; row++)
            {
                string[] rowData = Console.ReadLine().Split();
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] cmdArgs = command.Split();
                if (cmdArgs.Length != 5 || cmdArgs[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }
                int rowOne = int.Parse(cmdArgs[1]);
                int colOne = int.Parse(cmdArgs[2]);
                int rowTwo = int.Parse(cmdArgs[3]);
                int colTwo = int.Parse(cmdArgs[4]);

                bool isValidOne = isValidCell(rowOne, colOne, n, m);
                bool isValidTwo = isValidCell(rowTwo, colTwo, n, m);

                if (!isValidOne || !isValidTwo)
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }
                else
                {
                    string valueOne = matrix[rowOne, colOne];
                    string valueTwo = matrix[rowTwo, colTwo];
                    matrix[rowOne, colOne] = valueTwo;
                    matrix[rowTwo, colTwo] = valueOne;
                }

                PrintMatrix(matrix);


                command = Console.ReadLine();
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        private static bool isValidCell(int row, int col, int n, int m)
        {
            return row >= 0 && row < n && col >= 0 && col < m;
        }
    }
}
