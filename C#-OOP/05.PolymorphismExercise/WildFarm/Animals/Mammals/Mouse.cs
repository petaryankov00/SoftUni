using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override HashSet<string> AllowedFood => new HashSet<string> { "Vegetable", "Fruit" };

        public override double Gains => 0.10;

        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }
    }
}
