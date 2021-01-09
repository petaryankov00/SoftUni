using System;
using System.Collections.Generic;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> output = new Dictionary<string, List<double>>();
            string command = Console.ReadLine();

            while (command != "buy")
            {
                string[] currentProducts = command.Split();
                string productName = currentProducts[0];
                double price = double.Parse(currentProducts[1]);
                double quantity = double.Parse(currentProducts[2]);

                if (!output.ContainsKey(productName))
                {
                    List<double> priceAndQuantity = new List<double> { price, quantity };
                    output.Add(productName, priceAndQuantity);
                }
                else
                {
                    output[productName][0] = price;
                    output[productName][1] += quantity;
                }
                command = Console.ReadLine();
            }
            foreach (var item in output)
            {
                double totalPrice = item.Value[0] * item.Value[1];
                Console.WriteLine($"{item.Key} -> {totalPrice:f2}");
            }

        }
    }
}
