using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            int killTask = int.Parse(Console.ReadLine());

            int currThread = 0;
            int currTask = 0;

            while(threads.Count != 0)
            {
                currTask = tasks.Peek();
                currThread = threads.Peek();
                if (currTask == killTask)
                {
                    break;
                }
                else if (currThread >= currTask)
                {
                    tasks.Pop();
                    threads.Dequeue();                
                }
                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {currThread} killed task {killTask}");
            Console.WriteLine(string.Join(" ",threads));
        }
    }
}
