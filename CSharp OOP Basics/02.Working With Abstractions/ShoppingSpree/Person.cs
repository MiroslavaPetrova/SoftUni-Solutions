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
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                   throw new ArgumentOutOfRangeException("Money cannot be negative");
                }
                money = value;
            }
        }
        public List<Product> BagOfProducts { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
          
            if (this.BagOfProducts.Count > 0)
            {
                sb.AppendLine($"{this.Name} - {string.Join(", ", this.BagOfProducts.Select(p => p.Name))}");
            }
            else
            {
                sb.AppendLine($"{this.Name} - Nothing bought");
            }

            return sb.ToString().TrimEnd();
        }
       // public string IsPossilble => this.CanBuyProduct;
        public string CanBuyProduct(decimal productPrice, Product product)
        {
            StringBuilder sb = new StringBuilder();

            if (this.Money >= productPrice)
            {
                this.BagOfProducts.Add(product);
                this.Money -= productPrice;

                sb.AppendLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                sb.AppendLine($"{this.Name} can't afford {product.Name}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

       

 
        