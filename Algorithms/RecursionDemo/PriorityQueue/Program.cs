using System;
using System.Collections.Generic;

namespace PriorityQueueImplementation
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 10, 43, 21, 51, 4, 0, 124, 3, 6, };

            Console.WriteLine(String.Join(" ",numbers));
            PriorityQueue<int> queue = new PriorityQueue<int>();

            foreach (var n in numbers)
            {
                queue.Enqueue(n);
            }

            queue.DFS(0);
            Console.WriteLine();        
            Console.WriteLine();        
            Console.WriteLine();        
            while (queue.Size > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            
        }
    }
}
