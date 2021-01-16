using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> allClothes = new Stack<int>(clothesCapacity);

            int capacityBox = int.Parse(Console.ReadLine());
            int currRackCapacity = capacityBox;
            int racksCount = 1;
            while (allClothes.Any())
            {
                int clothe = allClothes.Pop();
                currRackCapacity -= clothe;

                if (currRackCapacity < 0)
                {
                    racksCount++;
                    currRackCapacity = capacityBox - clothe;
                }
            }
            Console.WriteLine(racksCount);

        }
    }
}
