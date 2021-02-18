using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> honor = ((name) =>
            {
                Console.WriteLine($"Sir {name}");
            });

             Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList().ForEach(honor);            
        }
    }
}
