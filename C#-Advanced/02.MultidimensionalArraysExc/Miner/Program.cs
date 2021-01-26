using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine().Split();
            string[,] field = new string[n, n];
            int minerRow = 0;
            int minerCol = 0;
            int sumOfCoals = 0;
            for (int row = 0; row < n; row++)
            {
                string[] data = Console.ReadLine().Split();
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = data[col];
                    if (field[row,col] == "s")
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                    if (field[row, col] == "c")
                    {
                        sumOfCoals++;
                    }
                }
            }
            bool isEnd = false;

            for (int i = 0; i < directions.Length; i++)
            {
                if (directions[i] == "up")
                {
                    if (!isValid(minerRow-1,minerCol,field))
                    {
                        continue;
                    }
                    minerRow -= 1;
                    if (field[minerRow,minerCol] == "e")
                    {
                        isEnd = true;
                        break;
                    }
                    else if (field[minerRow,minerCol] == "c")
                    {
                        field[minerRow, minerCol] = "*";
                        sumOfCoals--;
                        if (sumOfCoals == 0)
                        {
                            break;
                        }
                    }
                }
                else if (directions[i] == "down")
                {
                    if (!isValid(minerRow + 1, minerCol, field))
                    {
                        continue;
                    }
                    minerRow += 1;
                    if (field[minerRow, minerCol] == "e")
                    {
                        isEnd = true;
                        break;
                    }
                    else if (field[minerRow, minerCol] == "c")
                    {
                        field[minerRow, minerCol] = "*";
                        sumOfCoals--;
                        if (sumOfCoals == 0)
                        {
                            break;
                        }
                    }
                }
                else if (directions[i] == "left")
                {
                    if (!isValid(minerRow, minerCol-1, field))
                    {
                        continue;
                    }
                    minerCol -= 1;
                    if (field[minerRow, minerCol] == "e")
                    {
                        isEnd = true;
                        break;
                    }
                    else if (field[minerRow, minerCol] == "c")
                    {
                        field[minerRow, minerCol] = "*";
                        sumOfCoals--;
                        if (sumOfCoals == 0)
                        {
                            break;
                        }
                    }
                }
                else if (directions[i] == "right")
                {
                    if (!isValid(minerRow, minerCol+1, field))
                    {
                        continue;
                    }
                    minerCol += 1;
                    if (field[minerRow, minerCol] == "e")
                    {
                        isEnd = true;
                        break;
                    }
                    else if (field[minerRow, minerCol] == "c")
                    {
                        field[minerRow, minerCol] = "*";
                        sumOfCoals--;
                        if (sumOfCoals == 0)
                        {
                            break;
                        }
                    }
                }
            }

            if (isEnd)
            {
                Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
            }
            else if (sumOfCoals == 0)
            {
                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
            }
            else
            {
                Console.WriteLine($"{sumOfCoals} coals left. ({minerRow}, {minerCol})");
            }
        }

        private static bool isValid(int row, int col, string[,] field)
        {
            return row >= 0 && row < field.GetLength(0)
                && col >= 0 && col < field.GetLength(1);
        }
    }
}
