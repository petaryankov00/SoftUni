using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Cooking
{
    class Ingredient
    {
        public Ingredient(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            int[] ingredientsInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<Ingredient> ingredients = new Stack<Ingredient>();
            foreach (var value in ingredientsInfo)
            {
                Ingredient ingredient = new Ingredient(value);
                ingredients.Push(ingredient);
            }

            Dictionary<string, int> cookedFood = new Dictionary<string, int>{
                {"Bread",0 },
                {"Cake",0 },
                {"Pastry",0 },
                {"Fruit Pie",0 }
            };

            while (liquids.Count != 0 && ingredients.Count != 0)
            {
                int currLiquid = liquids.Peek();
                int currIngredient = ingredients.Peek().Value;
                int sum = currLiquid + currIngredient;

                if (sum == 25)
                {                   
                    liquids.Dequeue();
                    ingredients.Pop();
                    cookedFood["Bread"]++;
                }
                else if (sum == 50)
                {              
                    liquids.Dequeue();
                    ingredients.Pop();
                    cookedFood["Cake"]++;
                }
                else if (sum == 75)
                {                  
                    liquids.Dequeue();
                    ingredients.Pop();
                    cookedFood["Pastry"]++;
                }
                else if (sum == 100)
                {                 
                    liquids.Dequeue();
                    ingredients.Pop();
                    cookedFood["Fruit Pie"]++;
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Peek().Value += 3;
                 
                }
            }

            if (cookedFood["Bread"] != 0 && cookedFood["Cake"] != 0 && cookedFood["Pastry"] != 0 && cookedFood["Fruit Pie"] != 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count != 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Count != 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients.Select(i=>i.Value))}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }


            foreach (var food in cookedFood.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
        }
    }
}
