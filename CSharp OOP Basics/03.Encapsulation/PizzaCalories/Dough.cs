using System;

namespace PizzaCalories                         
{          
    public class Dough                          
    {                                                   
        private string flourType;                              
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight) 
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
                                                    
        public string FlourType
        {
            get => flourType; 
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value.ToLower();
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique; 
            private set
            {
                if (value.ToLower() != "crispy"
                    && value.ToLower() != "chewy"
                    && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value.ToLower();
            }
        }
        public int Weight
        {
            get => weight; 
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public double DoughCalories
        {
            get { return this.CalculateDoughCalories();}
        }

        private double CalculateDoughCalories()
        {
            double flourTypeModifier = 0.0;
            double bakingTechniqueModifier = 0.0;

            if (this.FlourType == "white")
            {
                flourTypeModifier = 1.5;
            }
            else
            {
                flourTypeModifier = 1.0;
            }
            if (this.BakingTechnique == "crispy")
            {
                bakingTechniqueModifier = 0.9;
            }
            else if (this.BakingTechnique == "chewy")
            {
                bakingTechniqueModifier = 1.1;
            }
            else
            {
                bakingTechniqueModifier = 1.0;
            }

            return 2 * this.Weight * flourTypeModifier * bakingTechniqueModifier;
        }
    }                                                    
}                                                        
