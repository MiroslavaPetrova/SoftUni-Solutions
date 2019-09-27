using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get{ return  name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Exception ae = new ArgumentException("Name cannot be empty");
                    Console.WriteLine(ae.Message);
                    Environment.Exit(0);
                }
                name = value; 
            }

        }
        public decimal Cost
        {
            get {return cost; }
            private set
            {
                if (value < 0)
                {
                    Exception ae = new ArgumentException("Money cannot be negative");
                    Console.WriteLine(ae.Message);
                    Environment.Exit(0);
                }
                cost = value;
            }
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
