using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;
       

        private string flourType;
        private string backingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                var valueAsLower = value.ToLower();
                if (valueAsLower != "white" && valueAsLower != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }

        }

        public string BakingTechnique
        {
            get => this.backingTechnique;
            private set
            {
                var valueAsLower = value.ToLower();

                if (valueAsLower != "chewy" &&
                    valueAsLower != "crispy" &&
                    valueAsLower != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.backingTechnique = value;
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    Validator.ThrowIfNumberIsNotInRange(MaxWeight, 
                        MinWeight, 
                        value, 
                        $"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
                }
                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double flourTypeModifier = 0;
            var toLowerFlourType = this.FlourType.ToLower();
            double bakingTechniqueModifier = 0;
            var toLowerBakingTechnique = this.BakingTechnique.ToLower();
            if (toLowerFlourType == "white")
            {
                flourTypeModifier = 1.5;
            }
            else
            {
                flourTypeModifier = 1;
            }

            if (toLowerBakingTechnique == "crispy")
            {
                bakingTechniqueModifier = 0.9;
            }
            else if (toLowerBakingTechnique == "chewy")
            {
                bakingTechniqueModifier = 1.1;
            }
            else
            {
                bakingTechniqueModifier = 1;
            }

            return this.Weight * 2 * flourTypeModifier * bakingTechniqueModifier;
        }
    }
}
