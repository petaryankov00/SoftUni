using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;


        private string name;
        private int weight;

        public Topping(string name,int weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                var valueAsLower = value.ToLower();
                if (valueAsLower != "meat" &&
                    valueAsLower != "cheese" &&
                    valueAsLower != "veggies" &&
                    valueAsLower != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.name = value;
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(MinWeight, MaxWeight, value,
                    $"{this.Name} weight should be in the range [1..50].");

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double toppingModifier = 0;
            var toppingNameLower = this.Name.ToLower();

            if (toppingNameLower == "meat")
            {
                toppingModifier = 1.2;
            }
            else if (toppingNameLower == "veggies")
            {
                toppingModifier = 0.8;
            }
            else if (toppingNameLower == "cheese")
            {
                toppingModifier = 1.1;
            }
            else
            {
                toppingModifier = 0.9;
            }

            return this.Weight * 2 * toppingModifier;
        }
    }
}
