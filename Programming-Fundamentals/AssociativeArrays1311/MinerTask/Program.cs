using System;
using System.Collections.Generic;

namespace MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string resources = Console.ReadLine();
            Dictionary<string, int> output = new Dictionary<string, int>();

            while (resources!= "stop")
            {
                int quantity = int.Parse(Console.ReadLine());
                if (!output.ContainsKey(resources))
                {
                    output.Add(resources, 0);
                }
                output[resources] += quantity;
                resources = Console.ReadLine();
            }
            foreach (var item in output)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
