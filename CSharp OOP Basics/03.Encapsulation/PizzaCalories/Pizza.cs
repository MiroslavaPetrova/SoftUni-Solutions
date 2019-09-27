using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
            this.Dough = dough;
        }

        public string Name
        {
            get => name;
            set
            {
                if (value.Length < 1 || value.Length > 15)
                { 
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        private Dough Dough { get; }

        private List<Topping> Toppings { get; }

        public int NumberOfToppings => this.Toppings.Count();
        
        public void AddTopping(Topping topping)
        {
            if (NumberOfToppings > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.Toppings.Add(topping);
        }

        public double TotalCalories
        {
            get { return this.CalculateTotalCalories(); }
        }

        private double CalculateTotalCalories()
        {
            double doughCalories = this.Dough.DoughCalories;
            double toppingCalories = this.Toppings.Sum(c => c.ToppingCalories);
            return doughCalories + toppingCalories;
        }
    }
}
