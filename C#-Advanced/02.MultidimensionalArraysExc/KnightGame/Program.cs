using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] chessBord = new char[n, n];
            int removedKnights = 0;


            for (int row = 0; row < n; row++)
            {
                string data = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    chessBord[row, col] = data[col];
                }
            }

            while (true)
            {
                int currentKnightEnemies = 0;
                int maxAttacks = int.MinValue;
                int killerRow = 0;
                int killerCol = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (chessBord[row, col] == 'K')
                        {
                            currentKnightEnemies = BordCell(chessBord, row, col, currentKnightEnemies);
                            if (currentKnightEnemies > maxAttacks)
                            {
                                maxAttacks = currentKnightEnemies;
                                killerRow = row;
                                killerCol = col;
                            }
                            currentKnightEnemies = 0;
                        }
                        
                    }
                }

                if (maxAttacks > 0)
                {
                    chessBord[killerRow, killerCol] = '0';
                    removedKnights++;
                    continue;
                }
                else
                {
                    Console.WriteLine(removedKnights);
                    break;
                }
            }


        }

      public static bool IsInside (char[,] chessBord, int row, int col)
      {
            return row >= 0 && row < chessBord.GetLength(0) && col >= 0
                 && col < chessBord.GetLength(1) && chessBord[row, col] == 'K';
      }

        public static int BordCell(char[,] chessBord, int row, int col, int currentKnightEnemies)
        {
            if (IsInside(chessBord, row + 2, col - 1))
            {
                currentKnightEnemies++;
            }
            if(IsInside(chessBord, row + 2, col + 1))
            {
                currentKnightEnemies++;
            }
            if(IsInside(chessBord, row - 2, col - 1))
            {
                currentKnightEnemies++;
            }
            if (IsInside(chessBord, row - 2, col + 1))
            {
                currentKnightEnemies++;
            }
            if (IsInside(chessBord, row + 1, col - 2))
            {
                currentKnightEnemies++;
            }
            if (IsInside(chessBord, row - 1, col + 2))
            {
                currentKnightEnemies++;
            }
            if (IsInside(chessBord, row + 1, col + 2))
            {
                currentKnightEnemies++;
            }
            if (IsInside(chessBord, row - 1, col - 2))
            {
                currentKnightEnemies++;
            }
            return currentKnightEnemies;
        }

    }
}
