using System;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private int weight;

        public Topping(string toppingType, int weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get => toppingType;
            set
            {
                if (value.ToLower() != "meat"
                    && value.ToLower() != "veggies"
                    && value.ToLower() != "cheese"
                    && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value; // only here without ToLower(), so the value we get
            }                        // later in the next exception message will not be  
        }                            // in lower case => e.g. toppingType value
                                     // another way w/ ToLower & with a new string variable = type...
        public int Weight            // string type = Char.ToUpper(this.ToppingType[0]) + this.ToppingType.Substring(1);
        {
            get => weight;
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{toppingType} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }
        public double ToppingCalories
        {
            get { return this.CalculateToppingCalories();}
        }

        private double CalculateToppingCalories()
        {
            double toppingModifier = 0.0;

            if (this.ToppingType.ToLower() == "meat")
            {
                toppingModifier = 1.2;
            }
            else if(this.ToppingType.ToLower() == "veggies")
            {
                toppingModifier = 0.8;
            }
            else if (this.ToppingType.ToLower() == "cheese")
            {
                toppingModifier = 1.1;
            }
            else
            {
                toppingModifier = 0.9;
            }

            return 2 * this.Weight * toppingModifier;
        }
    }
}
