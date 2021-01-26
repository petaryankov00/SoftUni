using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[n][];

            for (int row = 0; row < n; row++)
            {
                double[] rowData = Console.ReadLine().Split().Select(double.Parse).ToArray();
                jaggedArray[row] = new double[rowData.Length];
                for (int col = 0; col < rowData.Length; col++)
                {
                    jaggedArray[row][col] = rowData[col];
                }
            }

            for (int row = 0; row < n - 1; row++)
            {
                double[] firstArr = jaggedArray[row];
                double[] secondArr = jaggedArray[row+1];
                if (firstArr.Length == secondArr.Length)
                {
                   jaggedArray[row] = firstArr.Select(e => e * 2).ToArray();
                   jaggedArray[row+1] = secondArr.Select(e => e * 2).ToArray();
                }
                else
                {
                    jaggedArray[row] = firstArr.Select(e => e / 2).ToArray();
                    jaggedArray[row + 1] = secondArr.Select(e => e / 2).ToArray();
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArgs = command.Split();
                int rowIndex = int.Parse(cmdArgs[1]);
                int colIndex = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);
                bool isValid = rowIndex >= 0 && rowIndex < n && colIndex >= 0 && colIndex < jaggedArray[rowIndex].Length;
                if (!isValid)
                {
                    command = Console.ReadLine();
                    continue;
                }
                if (cmdArgs[0] == "Add")
                {                      
                    jaggedArray[rowIndex][colIndex] += value;
                }
                else if (cmdArgs[0] == "Subtract")
                {
                    jaggedArray[rowIndex][colIndex] -= value;
                }

                command = Console.ReadLine();
            }


            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(string.Join(" ",jaggedArray[row]));
            }
        }
    }
}
