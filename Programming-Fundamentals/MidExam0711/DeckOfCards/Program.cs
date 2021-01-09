using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> ownedCards = Console.ReadLine().Split(", ").ToList();
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string command = Console.ReadLine();
                string[] cmdArgs = command.Split(", ").ToArray();
                string firstCommand = cmdArgs[0];
                if (firstCommand == "Add")
                {
                    if (ownedCards.Contains(cmdArgs[1]))
                    {
                        Console.WriteLine("Card is already bought");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Card successfully bought");
                        ownedCards.Add(cmdArgs[1]);
                    }
                }
                else if (firstCommand == "Remove")
                {
                    if (ownedCards.Contains(cmdArgs[1]))
                    {
                        Console.WriteLine("Card successfully sold");
                        ownedCards.Remove(cmdArgs[1]);
                    }
                    else
                    {
                        Console.WriteLine("Card not found");
                    }
                }
                else if (firstCommand == "Remove At")
                {
                    int index = int.Parse(cmdArgs[1]);
                    if (index < 0 || index >= ownedCards.Count)
                    {
                        Console.WriteLine("Index out of range");
                    }
                    else
                    {
                        ownedCards.RemoveAt(index);
                        Console.WriteLine("Card successfully sold");
                    }
                }
                else if (firstCommand == "Insert")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string cardName = cmdArgs[2];
                    if (index < 0 || index >= ownedCards.Count)
                    {
                        Console.WriteLine("Index out of range");
                    }
                    else if (ownedCards.Contains(cardName))
                    {
                        Console.WriteLine("Card is already bought");
                    }
                    else
                    {
                        ownedCards.Insert(index, cardName);
                        Console.WriteLine("Card successfully bought");
                    }
                }
            }
            Console.WriteLine(string.Join(", ",ownedCards));
        }
    }
}
