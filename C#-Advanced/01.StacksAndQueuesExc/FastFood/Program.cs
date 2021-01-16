using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] ordersInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(ordersInput);

            Console.WriteLine(orders.Max());
            while (orders.Any())
            {
                int currOrder = orders.Peek();
                if (foodQuantity <= 0 || foodQuantity < currOrder)
                {
                    break;
                }               
                if (currOrder <= foodQuantity)
                {
                    foodQuantity -= currOrder;
                    orders.Dequeue();
                }
            }
            if (orders.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ",orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }

        }
    }
}
