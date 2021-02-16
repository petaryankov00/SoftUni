using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] teritory = new char[n, n];

            int snakeRow = -1;
            int snakeCol = -1;
            List<int> lairIndexes = new List<int>();
            int foodQuantity = 0;
            bool isOut = false;

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    teritory[row, col] = currentRow[col];
                    if (teritory[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    else if (teritory[row, col] == 'B')
                    {
                        lairIndexes.Add(row);
                        lairIndexes.Add(col);
                    }
                }
            }

            while (true)
            {
                string movement = Console.ReadLine();
                int currSnakeRow = snakeRow;
                int currSnakeCol = snakeCol;
                currSnakeRow = MoveRow(currSnakeRow, movement);
                currSnakeCol = MoveCol(currSnakeCol, movement);

                if (!isValid(currSnakeRow, currSnakeCol, teritory))
                {
                    isOut = true;
                    teritory[snakeRow, snakeCol] = '.';
                    break;
                }
                else if (teritory[currSnakeRow, currSnakeCol] == '*')
                {
                    foodQuantity++;                
                }
                else if (teritory[currSnakeRow, currSnakeCol] == 'B')
                {
                    if (currSnakeRow == lairIndexes[0] && currSnakeCol == lairIndexes[1])
                    {
                        currSnakeRow = lairIndexes[2];
                        currSnakeCol = lairIndexes[3];
                        teritory[lairIndexes[0], lairIndexes[1]] = '.';
                    }
                    else
                    {
                        currSnakeRow = lairIndexes[0];
                        currSnakeCol = lairIndexes[1];
                        teritory[lairIndexes[2], lairIndexes[3]] = '.';
                    }              
                }
                teritory[snakeRow, snakeCol] = '.';

                snakeRow = currSnakeRow;
                snakeCol = currSnakeCol;
                teritory[snakeRow, snakeCol] = 'S';


                if (foodQuantity >= 10)
                {
                    break;
                }

            }

            if (isOut)
            {
                Console.WriteLine("Game over!");
            }
            else 
            {
                Console.WriteLine($"You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");
            PrintMatrix(teritory);
        }

        private static void PrintMatrix(char[,] teritory)
        {
            for (int row = 0; row < teritory.GetLength(0); row++)
            {
                for (int col = 0; col < teritory.GetLength(1); col++)
                {
                    Console.Write(teritory[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool isValid(int currSnakeRow, int currSnakeCol, char[,] teritory)
        {
            return currSnakeRow >= 0 && currSnakeRow < teritory.GetLength(0)
                && currSnakeCol >= 0 && currSnakeCol < teritory.GetLength(1);
        }

        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }
            if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col - 1;
            }
            if (movement == "right")
            {
                return col + 1;
            }

            return col;
        }
    }
}
