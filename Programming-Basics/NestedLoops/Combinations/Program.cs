using System;
using System.Globalization;

namespace Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int combinations = 0;
            bool flag = false;
            
            for (int i = start; i <= end ; i++)
            {
                for (int j = start; j <= end ; j++)
                {
                    combinations++;
                    if (i + j == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{combinations} ({i} + {j} = {magicNumber})");
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
            if (flag == false)
            {
                Console.WriteLine($"{combinations} combinations - neither equals {magicNumber}");
            }
            

        }
    }
}
