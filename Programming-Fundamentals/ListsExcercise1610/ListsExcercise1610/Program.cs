﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ListsExcercise1610
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandArg = command.Split().ToArray();
                if (commandArg[0] == "Add")
                {                  
                    wagons.Add(int.Parse(commandArg[1]));
                }
                else
                {
                    int passengers = int.Parse(commandArg[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        int currentWagon = wagons[i];
                        bool isEnoughSpace = currentWagon + passengers <= maxCapacity;
                        if (isEnoughSpace)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                    
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",wagons));
        }
    }
}
