using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToList();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArg = command.Split();
                string firstArg = cmdArg[0];
                if (firstArg == "Shoot")
                {
                    int index = int.Parse(cmdArg[1]);
                    int power = int.Parse(cmdArg[2]);
                    if (index < 0 || index >= targets.Count)
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    targets[index] -= power;
                    if (targets[index]<=0)
                    {
                        targets.RemoveAt(index);
                    }
                }
                else if (firstArg == "Add")
                {
                    int index = int.Parse(cmdArg[1]);
                    int value = int.Parse(cmdArg[2]);
                    if (index < 0 || index >= targets.Count)
                    {
                        Console.WriteLine("Invalid placement!");
                        command = Console.ReadLine();
                        continue;
                    }
                    targets.Insert(index, value);
                }
                else if (firstArg == "Strike")
                {
                    int index = int.Parse(cmdArg[1]);
                    int radius = int.Parse(cmdArg[2]);
                    if (index < 0 || index >= targets.Count || index-radius<0 || index+radius>=targets.Count)
                    {
                        Console.WriteLine("Strike missed!");
                        command = Console.ReadLine();
                        continue;
                    }
                    targets.RemoveRange(index - radius, radius*2+1);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join("|",targets));
        }
    }
}
