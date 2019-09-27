using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    public class Book
    {
        private string author;
        private string title;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public string Author
        {
            get => author;
            set
            {
                string [] input = value.Split();

                if (input.Length > 1 && Char.IsDigit(input[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
                author = value;
            }
        }

        public string Title
        {
            get => title;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                title = value;
            }
        }

        public virtual decimal Price
        {
            get => price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                price = value;
            }
        }
        public override string ToString()
        {
            return $"Type: Book{Environment.NewLine}{GetBookInfo()}";
        }

        protected string GetBookInfo()
        {
            return  $"Title: {this.Title}{Environment.NewLine}" +
                    $"Author: {this.Author}{Environment.NewLine}" +
                    $"Price: {this.Price:f2}";
        }
    }
}
