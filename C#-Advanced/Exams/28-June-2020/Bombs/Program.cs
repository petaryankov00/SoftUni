using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Bombs
{
    class BombCasing
    {
        public BombCasing(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEfects = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Stack<BombCasing> bombCasings = new Stack<BombCasing>();
            int[] bombCasingInfo = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            foreach (var item in bombCasingInfo)
            {
                BombCasing currBombCasing = new BombCasing(item);
                bombCasings.Push(currBombCasing);
            }

            Dictionary<string, int> bombs = new Dictionary<string, int>
            {
                {"Datura Bombs",0 },
                {"Cherry Bombs",0 },
                {"Smoke Decoy Bombs",0 }
            };

            bool isBombPouchFull = false;

            while (bombEfects.Any() && bombCasings.Any())
            {
                int currBombEfect = bombEfects.Peek();
                int currBombCasing = bombCasings.Peek().Value;
                int sum = currBombEfect + currBombCasing;

                if (sum == 40)
                {
                    bombs["Datura Bombs"]++;
                    bombEfects.Dequeue();
                    bombCasings.Pop();
                }
                else if (sum == 60)
                {
                    bombs["Cherry Bombs"]++;
                    bombEfects.Dequeue();
                    bombCasings.Pop();
                }
                else if (sum == 120)
                {
                    bombs["Smoke Decoy Bombs"]++;
                    bombEfects.Dequeue();
                    bombCasings.Pop();
                }
                else
                {
                    bombCasings.Peek().Value -= 5;
                }

                if (bombs["Datura Bombs"] >= 3 && bombs["Cherry Bombs"] >= 3 && bombs["Smoke Decoy Bombs"] >=3)
                {
                    isBombPouchFull = true;
                    break;
                }
            }

            if (isBombPouchFull)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEfects.Any())
            {
                Console.WriteLine($"Bomb Effects: {String.Join(", ",bombEfects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasings.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ",bombCasings.Select(x=>x.Value))}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in bombs.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }

        }
    }
}
