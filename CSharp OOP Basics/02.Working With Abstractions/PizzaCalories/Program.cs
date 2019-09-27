using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Pizza Meatless                                               
            //Dough Wholegrain Crispy 100
            //Topping Veggies 50
            //Topping Cheese 50
            //END

            List<Pizza> pizzas = new List<Pizza>();

            string input = Console.ReadLine();

            while (input!= "END")
            {
                try
                {
                    string[] pizzaInfo = input.Split();
                    string name = pizzaInfo[1];
                    Pizza pizza = new Pizza(name);

                    string inputInfo = Console.ReadLine();
                    string[] doughInfo = inputInfo.Split();

                    string flour = doughInfo[1];
                    string baking = doughInfo[2];
                    double weight = double.Parse(doughInfo[3]);

                    Dough dough = new Dough(flour, baking, weight);
                    pizza.Dough = dough;

                    string inputLine = Console.ReadLine();

                    pizzas.Add(pizza);

                    while (inputLine != "END")
                    {
                        string[] toppingInfo = inputLine.Split();

                        string toppingType = toppingInfo[1];
                        double toppingWeight = double.Parse(toppingInfo[2]);

                        Topping topping = new Topping(toppingType, toppingWeight);
                        pizza.AddToipping(topping);

                        inputLine = Console.ReadLine();
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            foreach (var pizza in pizzas)
            {
                Console.WriteLine(pizza.ToString());
            }
        }
    }
}
