using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        

        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }
        public string ToppingType
        {
            get { return toppingType; }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" 
                    && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value;
            }
        }


        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public double ToppingCalories => this.CalculateTotalCalories();

        private double CalculateTotalCalories()
        {
            double toppingModifier = this.ToppingType.ToLower() == "meat" ? 1.2
                                    : this.ToppingType.ToLower() == "veggies" ? 0.8 
                                    : this.ToppingType.ToLower() == "cheese" ? 1.1 
                                    : 0.9;

            return 2 * this.Weight * toppingModifier;
        }
    }
}
