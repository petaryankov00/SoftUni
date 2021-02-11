using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            char[,] bakery = new char[n, n];

            int collectedMoney = 0;
            int playerRow = -1;
            int playerCol = -1;

            List<int> pillarsIndexes = new List<int>();

            for (int row = 0; row < n; row++)
            {
                char[] dataInfo = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    bakery[row, col] = dataInfo[col];
                    if (dataInfo[col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    else if (dataInfo[col] == 'O')
                    {
                        pillarsIndexes.Add(row);
                        pillarsIndexes.Add(col);
                    }
                }
            }

            bool isOutOfBakery = false;

            if (pillarsIndexes.Count == 0 || pillarsIndexes.Count == 4)
            {
                while (collectedMoney < 50)
                {
                    string command = Console.ReadLine();
                    int currRow = playerRow;
                    int currCol = playerCol;
                    if (command == "up")
                    {
                        if (!isValid(currRow - 1, currCol, bakery))
                        {
                            isOutOfBakery = true;
                            bakery[playerRow, playerCol] = '-';
                            break;
                        }
                        currRow--;
                        if (Char.IsDigit(bakery[currRow, currCol]))
                        {
                            int digit = (int)char.GetNumericValue(bakery[currRow, currCol]);
                            collectedMoney += digit;
                            bakery[playerRow, playerCol] = '-';
                        }
                        else if (bakery[currRow, currCol] == 'O')
                        {
                            if (playerRow == pillarsIndexes[0] && playerCol == pillarsIndexes[1])
                            {
                                currRow = pillarsIndexes[2];
                                currCol = pillarsIndexes[3];
                                bakery[pillarsIndexes[0], pillarsIndexes[1]] = '-';
                            }
                            else
                            {
                                currRow = pillarsIndexes[0];
                                currCol = pillarsIndexes[1];
                                bakery[pillarsIndexes[2], pillarsIndexes[3]] = '-';
                            }
                        }
                        else if (bakery[currRow, currCol] == '-')
                        {
                            bakery[playerRow, playerCol] = '-';
                        }

                        playerRow = currRow;
                        playerCol = currCol;
                        bakery[playerRow, playerCol] = 'S';
                        
                    }
                    else if (command == "down")
                    {
                        if (!isValid(currRow + 1, currCol, bakery))
                        {
                            isOutOfBakery = true;
                            bakery[playerRow, playerCol] = '-';
                            break;
                        }
                        currRow++;

                        if (Char.IsDigit(bakery[currRow, currCol]))
                        {
                            int digit = (int)char.GetNumericValue(bakery[currRow, currCol]);
                            collectedMoney += digit;
                            bakery[playerRow, playerCol] = '-';
                        }
                        else if (bakery[currRow, currCol] == 'O')
                        {
                            if (playerRow == pillarsIndexes[0] && playerCol == pillarsIndexes[1])
                            {
                                currRow = pillarsIndexes[2];
                                currCol = pillarsIndexes[3];
                                bakery[pillarsIndexes[0], pillarsIndexes[1]] = '-';
                            }
                            else
                            {
                                currRow = pillarsIndexes[0];
                                currCol = pillarsIndexes[1];
                                bakery[pillarsIndexes[2], pillarsIndexes[3]] = '-';
                            }
                        }
                        else if (bakery[currRow, currCol] == '-')
                        {
                            bakery[playerRow, playerCol] = '-';
                        }

                        playerRow = currRow;
                        playerCol = currCol;
                        bakery[playerRow, playerCol] = 'S';
                    }
                    else if (command == "left")
                    {
                        if (!isValid(currRow, currCol - 1, bakery))
                        {
                            isOutOfBakery = true;
                            bakery[playerRow, playerCol] = '-';
                            break;
                        }
                        currCol--;

                        if (Char.IsDigit(bakery[currRow, currCol]))
                        {
                            int digit = (int)char.GetNumericValue(bakery[currRow, currCol]);
                            collectedMoney += digit;
                            bakery[playerRow, playerCol] = '-';
                        }
                        else if (bakery[currRow, currCol] == 'O')
                        {
                            if (playerRow == pillarsIndexes[0] && playerCol == pillarsIndexes[1])
                            {
                                currRow = pillarsIndexes[2];
                                currCol = pillarsIndexes[3];
                                bakery[pillarsIndexes[0], pillarsIndexes[1]] = '-';
                            }
                            else
                            {
                                currRow = pillarsIndexes[0];
                                currCol = pillarsIndexes[1];
                                bakery[pillarsIndexes[2], pillarsIndexes[3]] = '-';
                            }
                        }
                        else if (bakery[currRow, currCol] == '-')
                        {
                            bakery[playerRow, playerCol] = '-';
                        }

                        playerRow = currRow;
                        playerCol = currCol;
                        bakery[playerRow, playerCol] = 'S';
                    }
                    else if (command == "right")
                    {
                        if (!isValid(currRow, currCol + 1, bakery))
                        {
                            isOutOfBakery = true;
                            bakery[playerRow, playerCol] = '-';
                            break;
                        }
                        currCol++;

                        if (Char.IsDigit(bakery[currRow, currCol]))
                        {
                            int digit = (int)char.GetNumericValue(bakery[currRow, currCol]);
                            collectedMoney += digit;
                            bakery[playerRow, playerCol] = '-';
                        }
                        else if (bakery[currRow, currCol] == 'O')
                        {
                            if (currRow == pillarsIndexes[0] && currCol == pillarsIndexes[1])
                            {
                                currRow = pillarsIndexes[2];
                                currCol = pillarsIndexes[3];
                                bakery[pillarsIndexes[0], pillarsIndexes[1]] = '-';
                                bakery[playerRow, playerCol] = '-';
                            }
                            else
                            {
                                currRow = pillarsIndexes[0];
                                currCol = pillarsIndexes[1];
                                bakery[pillarsIndexes[2], pillarsIndexes[3]] = '-';
                                bakery[playerRow, playerCol] = '-';
                            }
                        }
                        else if (bakery[currRow, currCol] == '-')
                        {
                            bakery[playerRow, playerCol] = '-';
                        }

                        playerRow = currRow;
                        playerCol = currCol;
                        bakery[playerRow, playerCol] = 'S';
                    }

                }
            }

            if (isOutOfBakery)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {collectedMoney}");

            PrintMatrix(bakery);

        }
    

        private static void PrintMatrix(char[,] bakery)
        {
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    Console.Write(bakery[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static bool isValid(int playerRow, int playerCol, char[,] bakery)
        {
            return playerRow >= 0 && playerRow < bakery.GetLength(0)
                && playerCol >= 0 && playerCol < bakery.GetLength(1);
        }
    }
}
