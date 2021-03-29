using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal
    {
        public Animal(string name,double weight)
        {
            Name = name;
            Weight = weight;
        }

        public abstract HashSet<string> AllowedFood { get; }

        public abstract double Gains { get; }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; set; }

        public abstract void ProduceSound();

        public void Eat(Food food)
        {
            if (!AllowedFood.Contains(food.GetType().Name))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            FoodEaten += food.Quantity;
            Weight += food.Quantity * Gains;
        }

        

    }
}
