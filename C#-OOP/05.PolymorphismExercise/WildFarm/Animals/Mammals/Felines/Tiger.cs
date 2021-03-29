using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override HashSet<string> AllowedFood => new HashSet<string> { "Meat" };

        public override double Gains => 1.00;

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
