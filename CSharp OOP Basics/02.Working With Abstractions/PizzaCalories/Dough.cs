using System;

namespace PizzaCalories
{
    public class Dough
    {
   

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => flourType; 
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException($"Invalid type of dough.");
                }
                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique; 
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException($"Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }

        public double Weight
        {
            get =>  weight; 
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentOutOfRangeException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public double DoughCalories => this.CalculateCalories();

        private double CalculateCalories()
        {
            double flourModifier = this.FlourType.ToLower() == "white" ? 1.5 : 1.0;

            double bakingTechniqueModifier = this.BakingTechnique.ToLower() == "crispy" ? 0.9
                                            : this.BakingTechnique.ToLower() == "chewy" ? 1.1 : 1.0;

            return (2 * this.Weight) * flourModifier * bakingTechniqueModifier;
        }
    }
}
