using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalSum = 0;
            
            while (input != "Start")
            {
                double insertCoin = double.Parse(input);
                bool validation = insertCoin != 0.1 &&
                                  insertCoin != 0.2 &&
                                  insertCoin != 0.5 &&
                                  insertCoin != 1   &&
                                  insertCoin != 2;
                if (validation)
                {
                    Console.WriteLine($"Cannot accept {insertCoin}");
                    
                }
                else
                {
                    totalSum += insertCoin;
                }
                    input = Console.ReadLine();
            }
            string product = Console.ReadLine();
            double price = 0;
            while (product != "End")
            {
                switch (product)
                {
                    case "Nuts": price = 2.0; break;
                    case "Water": price = 0.7; break;
                    case "Crisps": price = 1.5; break;
                    case "Soda": price = 0.8; break;
                    case "Coke": price = 1; break;
                    default: Console.WriteLine("Invalid product");
                        product = Console.ReadLine();
                        continue;


                }
                if (price <= totalSum)
                {
                    totalSum -= price;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                  product = Console.ReadLine();
            }
            Console.WriteLine($"Change: {totalSum:f2}");
        }
    }
}
