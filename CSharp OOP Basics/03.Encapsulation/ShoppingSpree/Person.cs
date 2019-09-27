using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product>bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = new List<Product>();
        }

        public string Name
        {
            get { return name; }
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
        public decimal Money
        {
            get{ return money; }
            private set
            {
                if (value < 0)
                {
                    Exception ae = new ArgumentException("Money cannot be negative");
                    Console.WriteLine(ae.Message);
                    Environment.Exit(0);
                }
                money = value;
            }
        }
        public List<Product> BagOfProducts { get => bagOfProducts; set => bagOfProducts = value; }

        public void AddToBag(Product product)
        {
            decimal cost = product.Cost;
            string productName = product.Name;

            if (cost > this.money) // try Money prop
            {
                Console.WriteLine($"{this.Name} can't afford {productName}");
            }
            else
            {
                this.BagOfProducts.Add(product);
                this.Money -= cost;
                Console.WriteLine($"{this.Name} bought {productName}");
            }
        }
        public override string ToString()
        {
            if (bagOfProducts.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }
            else
            {
                return $"{this.Name} -" +
                    $" {string.Join(", ",bagOfProducts.Select(p => p.ToString()))}";
            }
        }
    }
}
