using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] field = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = data[col];
                }
            }

            string[] bombsIndexes = Console.ReadLine().Split();

            for (int i = 0; i < bombsIndexes.Length; i++)
            {
                int[] currBombIndexes = bombsIndexes[i].Split(",").Select(int.Parse).ToArray();
                int currRow = currBombIndexes[0];
                int currCol = currBombIndexes[1];
                int damage = field[currRow, currCol];
                if (isValid(currRow,currCol,field) && field[currRow,currCol] > 0)
                {
                   field =  MatrixAfterExplosion(currRow, currCol, field,damage);
                   field[currRow, currCol] = 0;
                }             
            }

            List<int> aliveNumbers = new List<int>();
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (field[row, col] > 0)
                    {
                        aliveNumbers.Add(field[row, col]);
                    }
                }
            }
            int sum = aliveNumbers.Sum();
            Console.WriteLine($"Alive cells: {aliveNumbers.Count}");
            Console.WriteLine($"Sum: {sum}");
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {                                      
                  Console.Write($"{field[row,col]} ");                    
                }
                Console.WriteLine();
            }


        }

        private static bool isValid(int row, int col, int[,] field)
        {
            return row >= 0 && row < field.GetLength(0)
                && col >= 0 && col < field.GetLength(1);
        }
        public static int[,] MatrixAfterExplosion(int row,int col, int[,] field,int damage)
        {
            if (isValid(row-1,col,field))
            {
                if (field[row - 1, col] > 0)
                {
                    field[row - 1, col] -= damage;
                }
                
            }
            if (isValid(row - 1, col-1, field))
            {
                if (field[row - 1, col - 1] > 0)
                {
                    field[row - 1, col - 1] -= damage;
                }
                
            }
            if (isValid(row, col - 1, field))
            {
                if (field[row, col - 1] > 0)
                {
                    field[row, col - 1] -= damage;
                }
               
            }
            if (isValid(row + 1, col-1, field))
            {
                if (field[row + 1, col - 1] > 0)
                {
                    field[row + 1, col - 1] -= damage;
                }
                
            }
            if (isValid(row + 1, col, field))
            {
                if (field[row + 1, col] > 0)
                {
                    field[row + 1, col] -= damage;
                }
                
            }
            if (isValid(row + 1, col + 1, field))
            {
                if (field[row + 1, col + 1] > 0)
                {
                    field[row + 1, col + 1] -= damage;
                }
                
            }
            if (isValid(row, col + 1, field))
            {
                if (field[row, col + 1] > 0)
                {
                    field[row, col + 1] -= damage;
                }
                
            }
            if (isValid(row - 1, col + 1, field))
            {
                if (field[row - 1, col + 1] > 0)
                {
                    field[row - 1, col + 1] -= damage;
                }              
            }
            return field;
        }
    }
}
