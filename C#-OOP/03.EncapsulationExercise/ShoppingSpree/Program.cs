using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] peopleInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] productsInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            
            try
            {
                foreach (var personInfo in peopleInfo)
                {
                    string[] currPerson = personInfo.Split("=",StringSplitOptions.RemoveEmptyEntries);
                    string name = currPerson[0];
                    double money = double.Parse(currPerson[1]);
                    Person person = new Person(name, money);
                    people.Add(name, person);
                }

                foreach (var productInfo in productsInfo)
                {
                    string[] currProduct = productInfo.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = currProduct[0];
                    double cost = double.Parse(currProduct[1]);
                    Product product = new Product(name, cost);
                    products.Add(name, product);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                var parts = command.Split();
                string personName = parts[0];
                string productName = parts[1];

                Person person = people[personName];
                Product product = products[productName];

                try
                {
                    person.AddProduct(product);
                    Console.WriteLine($"{personName} bought {productName}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }

            foreach (var person in people.Values)
            {
                Console.WriteLine(person);
            }
        }
    }
}
