using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfOneBullet = int.Parse(Console.ReadLine());
            int gunBarrelCapacity = int.Parse(Console.ReadLine());

            int[] bulletsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bullets = new Stack<int>(bulletsInput);

            int[] locksInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> locks = new Queue<int>(locksInput);

            int intelligenceValue = int.Parse(Console.ReadLine());
            int currBarrelCapacity = gunBarrelCapacity;
            int bulletsCount = 0;

            while (bullets.Any() && locks.Any())
            {         
                bulletsCount++;
                currBarrelCapacity--;
                int currBullet = bullets.Pop();
                int currLock = locks.Peek();

                if (currBullet <= currLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }               
                if (currBarrelCapacity == 0)
                {
                    if (bullets.Any())
                    {
                        currBarrelCapacity = gunBarrelCapacity;
                        Console.WriteLine("Reloading!");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (locks.Count == 0)
            {             
                int intelligenceUsed = bulletsCount * priceOfOneBullet;
                intelligenceValue -= intelligenceUsed;
                Console.WriteLine($"{bullets.Count()} bullets left. Earned ${intelligenceValue}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count()}");
            }

        }
    }
}
