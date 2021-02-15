using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] teritory = new char[n, n];

            int beeRow = -1;
            int beeCol = -1;
            int bonusRow = -1;
            int bonusCol = -1;
            int bonus = 0;

            for (int row = 0; row < n; row++)
            {
                char[] dataInfo = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    teritory[row, col] = dataInfo[col];
                    if (teritory[row,col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                    else if (teritory[row, col] == 'O')
                    {
                        bonus++;
                        bonusRow = row;
                        bonusCol = col;
                    }
                }
            }

            bool isLost = false;
            int flowers = 0;
            string command = Console.ReadLine();

            if (bonus == 1 || bonus == 0)
            {
                while (command != "End")
                {
                    int currentBeeRow = beeRow;
                    int currentBeeCol = beeCol;
                    if (command == "up")
                    {
                        currentBeeRow--;
                    }
                    else if (command == "down")
                    {
                        currentBeeRow++;
                    }
                    else if (command == "left")
                    {
                        currentBeeCol--;
                    }
                    else if (command == "right")
                    {
                        currentBeeCol++;
                    }

                    if (!IsValid(currentBeeRow, currentBeeCol, teritory))
                    {
                        isLost = true;
                        teritory[beeRow, beeCol] = '.';
                        break;
                    }
                    else if (teritory[currentBeeRow,currentBeeCol] == 'f')
                    {
                        flowers++;
                        teritory[beeRow, beeCol] = '.';
                    }
                    else if (teritory[currentBeeRow, currentBeeCol] == '.')
                    {
                        teritory[beeRow, beeCol] = '.';
                    }
                    else
                    {
                        teritory[bonusRow, bonusCol] = '.';
                        if (command == "up")
                        {
                            currentBeeRow--;
                        }
                        else if (command == "down")
                        {
                            currentBeeRow++;
                        }
                        else if (command == "left")
                        {
                            currentBeeCol--;
                        }
                        else if (command == "right")
                        {
                            currentBeeCol++;
                        }

                        if (teritory[currentBeeRow, currentBeeCol] == 'f')
                        {
                            flowers++;
                            teritory[beeRow, beeCol] = '.';
                        }
                        else if (teritory[currentBeeRow, currentBeeCol] == '.')
                        {
                            teritory[beeRow, beeCol] = '.';
                        }
                    }

                    beeRow = currentBeeRow;
                    beeCol = currentBeeCol;
                    teritory[beeRow, beeCol] = 'B';
                    command = Console.ReadLine();
                }
            }

            if (isLost)
            {
                Console.WriteLine("The bee got lost!");
            }

            if (flowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-flowers} flowers more");
            }

            PrintMatrix(teritory);

        }

        private static void PrintMatrix(char[,] teritory)
        {
            for (int row = 0; row < teritory.GetLength(0); row++)
            {
                for (int col = 0; col < teritory.GetLength(1); col++)
                {
                    Console.Write(teritory[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsValid(int currentBeeRow, int currentBeeCol, char[,] teritory)
        {
            return currentBeeRow >= 0 && currentBeeRow < teritory.GetLength(0)
                && currentBeeCol >= 0 && currentBeeCol < teritory.GetLength(1);
        }
    }
}
