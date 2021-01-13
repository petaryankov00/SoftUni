using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            Queue<string> potatoQueue = new Queue<string>(children);
            int counter = 0;
            while (potatoQueue.Count > 1)
            {
                counter++;
                string kid = potatoQueue.Dequeue();                
                if (counter == n)
                {
                    Console.WriteLine($"Removed {kid}");
                    counter = 0;
                }
                else
                {
                    potatoQueue.Enqueue(kid);
                }
                
            }
            Console.WriteLine($"Last is {potatoQueue.Dequeue()}");
            
        }
    }
}
