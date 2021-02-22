using System;
using System.Linq;
using System.Numerics;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] inputCoordinates = Console.ReadLine().Split(new char[] { ',', ' ' },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = new char[n, n];
            int playerOneShips = 0;
            int playerTwoShips = 0;
            int shipsDestroyed = 0;
            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();          
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == '<')
                    {
                        playerOneShips++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        playerTwoShips++;
                    }
                }
            }
            bool hasFirstWon = false;
            bool hasSecondWon = false;           
            for (int i = 0; i < inputCoordinates.Length; i += 2)
            {
                int currRow = inputCoordinates[i];
                int currCol = inputCoordinates[i + 1];
                if (!isValid(matrix, currRow, currCol))
                {
                    continue;
                }
                char currentPostion = matrix[currRow, currCol];               
                if (currentPostion == '>')
                {
                    playerTwoShips--;
                    shipsDestroyed++;
                }
                else if (currentPostion == '<')
                {
                    playerOneShips--;
                    shipsDestroyed++;
                }
                else if (currentPostion == '#')
                {
                    if (isValid(matrix, currRow - 1, currCol))
                    {
                        char currentChar = matrix[currRow - 1, currCol];
                        if (currentChar == '>')
                        {

                            playerTwoShips--;
                            shipsDestroyed++;
                        }
                        else if (currentChar == '<')
                        {

                            playerOneShips--;
                            shipsDestroyed++;
                        }
                        matrix[currRow - 1, currCol] = 'X';
                    }
                    if (isValid(matrix, currRow + 1, currCol))
                    {
                        char currentChar = matrix[currRow + 1, currCol];
                        if(currentChar == '>')
                        {

                            playerTwoShips--;
                            shipsDestroyed++;
                        }
                        else if (currentChar == '<')
                        {

                            playerOneShips--;
                            shipsDestroyed++;
                        }
                        matrix[currRow + 1, currCol] = 'X';
                    }
                    if (isValid(matrix, currRow, currCol - 1))
                    {
                        char currentChar = matrix[currRow, currCol - 1];
                        if (currentChar == '>')
                        {

                            playerTwoShips--;
                            shipsDestroyed++;
                        }
                        else if (currentChar == '<')
                        {

                            playerOneShips--;
                            shipsDestroyed++;
                        }
                        matrix[currRow, currCol - 1] = 'X';
                    }
                    if (isValid(matrix, currRow, currCol + 1))
                    {
                        char currentChar = matrix[currRow, currCol + 1];
                        if (currentChar == '>')
                        {

                            playerTwoShips--;
                            shipsDestroyed++;
                        }
                        else if (currentChar == '<')
                        {

                            playerOneShips--;
                            shipsDestroyed++;
                        }
                        matrix[currRow, currCol + 1] = 'X';
                    }
                    if (isValid(matrix, currRow + 1, currCol + 1))
                    {
                        char currentChar = matrix[currRow + 1, currCol + 1];
                        if (currentChar == '>')
                        {

                            playerTwoShips--;
                            shipsDestroyed++;
                        }
                        else if (currentChar == '<')
                        {

                            playerOneShips--;
                            shipsDestroyed++;
                        }

                        matrix[currRow + 1, currCol + 1] = 'X';
                    }
                    if (isValid(matrix, currRow - 1, currCol - 1))
                    {
                        char currentChar = matrix[currRow - 1, currCol - 1];
                        if (currentChar == '>')
                        {

                            playerTwoShips--;
                            shipsDestroyed++;
                        }
                        else if (currentChar == '<')
                        {

                            playerOneShips--;
                            shipsDestroyed++;
                        }

                        matrix[currRow - 1, currCol - 1] = 'X';
                    }
                    if (isValid(matrix, currRow + 1, currCol - 1))
                    {
                        char currentChar = matrix[currRow + 1, currCol - 1];
                        if (currentChar == '>')
                        {

                            playerTwoShips--;
                            shipsDestroyed++;
                        }
                        else if (currentChar == '<')
                        {

                            playerOneShips--;
                            shipsDestroyed++;
                        }

                        matrix[currRow + 1, currCol - 1] = 'X';
                    }
                    if (isValid(matrix, currRow - 1, currCol + 1))
                    {
                        char currentChar = matrix[currRow - 1, currCol + 1];
                        if (currentChar == '>')
                        {

                            playerTwoShips--;
                            shipsDestroyed++;
                        }
                        else if (currentChar == '<')
                        {

                            playerOneShips--;
                            shipsDestroyed++;
                        }
                        matrix[currRow - 1, currCol + 1] = 'X';
                    }                
                }
                matrix[currRow, currCol] = 'X';
                if (playerOneShips <= 0)
                {
                    hasSecondWon = true;
                    break;
                }
                if (playerTwoShips <= 0)
                {
                    hasFirstWon = true;
                    break;
                }
            }
            if (hasFirstWon)
            {
                Console.WriteLine($"Player One has won the game! {shipsDestroyed} ships have been sunk in the battle.");
            }
            else if (hasSecondWon)
            {
                Console.WriteLine($"Player Two has won the game! {shipsDestroyed} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }
        }
        public static bool isValid(char[,] matrix, int currRow, int currCol)
        {
            return currRow >= 0 && currRow < matrix.GetLength(0) &&
                currCol >= 0 && currCol < matrix.GetLength(1);
        }
    }
}
