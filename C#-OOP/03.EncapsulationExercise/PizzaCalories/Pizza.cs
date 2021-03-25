using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MinLength = 1;
        private const int MaxLength = 15;

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name,Dough dough)
        {
            Name = name;
            this.dough = dough;
            toppings = new List<Topping>();
        }

        public string Name 
        {
            get => this.name;
            set
            {
                if (value.Length < MinLength || value.Length > MaxLength)
                {
                    throw new ArgumentException($"Pizza name should be between {MinLength} and {MaxLength} symbols.");
                }
                this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

        public double GetCalories()
        {
            return this.dough.GetCalories() + this.toppings.Sum(x => x.GetCalories());
        }

        
    }
}
