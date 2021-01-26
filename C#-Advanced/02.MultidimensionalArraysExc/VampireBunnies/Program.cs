using System;
using System.Collections.Generic;
using System.Linq;

namespace VampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = dimensions[0];
            int m = dimensions[1];
            char[,] field = new char[n, m];
            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                for (int col = 0; col < m; col++)
                {
                    field[row, col] = rowData[col];
                    if (field[row,col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();
            bool isWon = false;
            bool isDead = false;

            foreach (char direction in directions)
            {
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                if (direction == 'U')
                {
                    newPlayerRow--;
                }
                else if (direction == 'L')
                {
                    newPlayerCol--;                    
                }
                else if (direction == 'R')
                {
                    newPlayerCol++;
                }
                else if (direction == 'D')
                {
                    newPlayerRow++;
                }

                if (!isValidCell(newPlayerRow,newPlayerCol,n,m))
                {
                    isWon = true;
                    field[playerRow, playerCol] = '.';
                    List<int[]> bunniesCoordinates = GetBunniesCoordinates(field);
                    SpreadBunnies(bunniesCoordinates, field);
                }
                else if (field[newPlayerRow,newPlayerCol] == '.')
                {
                    field[playerRow, playerCol] = '.';
                    field[newPlayerRow, newPlayerCol] = 'P';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                    List<int[]> bunniesCoordinates = GetBunniesCoordinates(field);
                    SpreadBunnies(bunniesCoordinates, field);

                    if (field[playerRow,playerCol] == 'B')
                    {
                        isDead = true;
                    }
                }
                else if (field[newPlayerRow, newPlayerCol] == 'B')
                {
                    isDead = true;
                    field[playerRow, playerCol] = '.';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                    List<int[]> bunniesCoordinates = GetBunniesCoordinates(field);
                    SpreadBunnies(bunniesCoordinates, field);
                }
                if (isWon || isDead)
                {
                    break;
                }             
            }
            PrintField(field);
            if (isWon)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else if (isDead)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
        }

        private static void PrintField(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static void SpreadBunnies(List<int[]> bunniesCoordinates, char[,] field)
        {
            int rowLength = field.GetLength(0);
            int colLength = field.GetLength(1);

            foreach (int[] currBunny in bunniesCoordinates)
            {
                int row = currBunny[0];
                int col = currBunny[1];

                if (isValidCell(row - 1,col,rowLength,colLength))
                {
                    field[row - 1, col] = 'B';
                }
                if (isValidCell(row + 1, col, rowLength, colLength))
                {
                    field[row + 1, col] = 'B';
                }
                if (isValidCell(row, col-1, rowLength, colLength))
                {
                    field[row, col-1] = 'B';
                }
                if (isValidCell(row, col+1, rowLength, colLength))
                {
                    field[row, col+1] = 'B';
                }
            }
        }

        private static List<int[]> GetBunniesCoordinates(char[,] field)
        {
            List<int[]> bunniesCoordinates = new List<int[]>();
            for (int row = 0; row < field.GetLength(0); row++)
            {              
                for (int col = 0; col < field.GetLength(1); col++)
                {                  
                    if (field[row, col] == 'B')
                    {
                        bunniesCoordinates.Add(new int[] { row, col });
                                               
                    }
                }
            }
            return bunniesCoordinates;
        }

        private static bool isValidCell(int row, int col, int n, int m)
        {
            return row >= 0 && row < n && col >= 0 && col < m;
        }
    }
}
