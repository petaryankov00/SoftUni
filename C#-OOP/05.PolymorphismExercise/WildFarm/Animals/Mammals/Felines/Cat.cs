using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override HashSet<string> AllowedFood => new HashSet<string> { "Vegetable", "Meat" };

        public override double Gains => 0.3;

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
