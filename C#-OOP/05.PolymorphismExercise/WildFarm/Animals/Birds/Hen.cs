using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override HashSet<string> AllowedFood => new HashSet<string> 
        { "Vegetable", "Fruit", "Meat", "Seeds" };

        public override double Gains => 0.35;

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
