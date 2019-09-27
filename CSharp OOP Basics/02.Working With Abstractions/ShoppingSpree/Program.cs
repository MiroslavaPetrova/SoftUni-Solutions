using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            // Pesho=11;Gosho=4
            // Bread=10;Milk=2;

            string[] allPeople = Console.ReadLine().Split(new char[] {';', '='},StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < allPeople.Length; i += 2)
            {
                string name = allPeople[i];
                decimal money = decimal.Parse(allPeople[i + 1]);

                Person person = new Person(name, money);
                people.Add(person);
            }
            string[] allProducts = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < allProducts.Length; i += 2)
            {
                string name = allProducts[i];
                decimal cost = decimal.Parse(allProducts[i + 1]);

                Product product = new Product(name, cost);
                products.Add(product);
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                try
                {
                    string[] inputArgs =input.Split();
                    string personName= inputArgs[0];
                    string productName = inputArgs[1];

                    Person targetPerson = people.FirstOrDefault(p => p.Name == personName);
                    Product targetProduct = products.FirstOrDefault(p => p.Name == productName);

                    var result = targetPerson.CanBuyProduct(targetProduct.Cost, targetProduct);
                    Console.WriteLine(result);

                    input = Console.ReadLine();
                    continue;
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                    break;
                }
            }

            foreach (var person in people)                                     
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
