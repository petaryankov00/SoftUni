using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override HashSet<string> AllowedFood => new HashSet<string> { "Meat" };

        public override double Gains => 0.25;

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
