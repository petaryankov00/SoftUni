using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizzaName = Console.ReadLine().Split()[1];

            var doughData = Console.ReadLine().Split();

            string flourType = doughData[1];
            string bakingTechnique = doughData[2];
            int weight = int.Parse(doughData[3]);
            try
			{              
                Dough dough = new Dough(flourType, bakingTechnique, weight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string line = Console.ReadLine();

                while (line != "END")
                {
                    var parts = line.Split();

                    var toppingName = parts[1];
                    var toppingWeight = int.Parse(parts[2]);

                    Topping topping = new Topping(toppingName, toppingWeight);

                    pizza.AddTopping(topping);

                    line = Console.ReadLine();
                }

                Console.WriteLine($"{pizzaName} - {pizza.GetCalories():f2} Calories.");
            }
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
                				
			}
        }
    }
}
