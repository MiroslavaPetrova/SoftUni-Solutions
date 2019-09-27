using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length > 15 || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }

        public List<Topping> Toppings { get; }
    
        public void AddToipping(Topping topping)
        {
            if (this.Toppings.Count < 10)
            {
                this.Toppings.Add(topping);
            }
            else
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
        }

        public double TotalPizzaCalories 
            => this.Toppings.Sum(t => t.ToppingCalories) + this.Dough.DoughCalories;

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalPizzaCalories:F2} Calories.";
        }
    }
}
