using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Loot
{
    class Program
    {       
        static void Main(string[] args)
        {
            List<string> loots = Console.ReadLine().Split("|").ToList();
            string command = Console.ReadLine();

            while (command != "Yohoho!")
            {
                string[] cmdArgs = command.Split().ToArray();
                string firstCommand = cmdArgs[0];
                if (firstCommand == "Loot")
                {                   
                    for (int i = 1; i < cmdArgs.Length; i++)
                    {
                        if (loots.Contains(cmdArgs[i]))
                        {
                            continue;
                        }
                        else
                        {
                            loots.Insert(0, cmdArgs[i]);
                        }
                    }
                    
                }
                else if (firstCommand == "Drop")
                {                   
                    int index = int.Parse(cmdArgs[1]);
                    if (index < 0 || index >= loots.Count)
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    string item = loots[index];
                    loots.Remove(item);
                    loots.Add(item); 
                }
                else if (firstCommand == "Steal")
                {
                    int removeCount = int.Parse(cmdArgs[1]);
                    if (removeCount <= loots.Count)
                    {
                        List<string> removeItems = new List<string>();
                        for (int i = loots.Count-removeCount; i < loots.Count; i++)
                        {
                            string currItem = loots[i];
                            loots.Remove(currItem);
                            removeItems.Add(currItem);
                            i--;
                        }
                        Console.WriteLine(string.Join(", ",removeItems));
                    }
                    else
                    {
                        Console.WriteLine(string.Join(", ", loots));
                        loots.RemoveRange(0, loots.Count);
                    }
                }
                command = Console.ReadLine();
            }
            double counter = 0;
            if (loots.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                for (int i = 0; i < loots.Count; i++)
                {
                    string currElement = loots[i];
                    char[] letters = currElement.ToCharArray();
                    for (int j = 0; j < letters.Length; j++)
                    {
                        counter++;
                    }
                }
                double averageSum = counter / loots.Count;
                Console.WriteLine($"Average treasure gain: {averageSum:f2} pirate credits.");
            }
        }
    }
}
