using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    public  class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string title, string author, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Title
        {
            get => this.title;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                this.title = value;
            }

        }

        public string Author
        {
            get => this.author;
            set
            {
                string secondName = value.Split()[1];

                if (char.IsDigit(secondName[0]))
                {
                    throw new ArgumentException("Author not valid!");
                }

                this.author = value;
            }
            
        }

        public virtual decimal Price
        {
            get => this.price;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Title: {this.Title}");
            sb.AppendLine($"Author: {this.Author}");
            sb.AppendLine($"Price: {this.Price:F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
