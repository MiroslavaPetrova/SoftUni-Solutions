using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] allPeople = Console.ReadLine()
                .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] allProducts = Console.ReadLine()
                .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < allPeople.Length; i++)
            {
                string[] tokens = allPeople[i].Split("=");
                string name = tokens[0];
                decimal money = decimal.Parse(tokens[1]);

                Person person = new Person(name, money);
                people.Add(person);
            }
            for (int i = 0; i < allProducts.Length; i++)
            {
                string[] tokens = allProducts[i].Split("=");
                string name = tokens[0];
                decimal cost = decimal.Parse(tokens[1]);

                Product product = new Product(name, cost);
                products.Add(product);
            }
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] info = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string person = info[0];
                string productName = info[1];

                Product product = products.First(p => p.Name == productName);
                people.First(p => p.Name == person).AddToBag(product);
                
                input = Console.ReadLine();
            }
            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
