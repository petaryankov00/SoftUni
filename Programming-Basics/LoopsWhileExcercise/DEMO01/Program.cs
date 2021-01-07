﻿using System;

namespace DEMO01
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double countPieces = length * width;
            string pieces = Console.ReadLine();
            while (pieces != "STOP")
            {
                if (countPieces < 0)
                {
                    break;
                }
                countPieces -= double.Parse(pieces);
                pieces = Console.ReadLine();
            }
            if (countPieces >= 0)
            {
                Console.WriteLine($"{countPieces} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(countPieces)} pieces more.");
            }
        }
    }
}
