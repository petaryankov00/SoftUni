using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override HashSet<string> AllowedFood => new HashSet<string> { "Meat" };

        public override double Gains => 0.40;

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
