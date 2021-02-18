using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstLootBox = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> secondLootBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int claimedItemsSum = 0;
           

            while(true)
            {
                int firstItem = firstLootBox.Peek();
                int secondItem = secondLootBox.Peek();
                int sum = firstItem + secondItem;

                if (sum % 2 == 0)
                {
                    claimedItemsSum += sum;
                    firstLootBox.Dequeue();
                    secondLootBox.Pop();
                }
                else
                {
                    secondLootBox.Pop();
                    firstLootBox.Enqueue(secondItem);
                }

                if (!firstLootBox.Any())
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }

                if (!secondLootBox.Any())
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }
            }

            if (claimedItemsSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItemsSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItemsSum}");
            }
        }
    }
}
