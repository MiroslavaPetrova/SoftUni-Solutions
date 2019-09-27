using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)    
        {
                    // Pizza Meatless
                    // Dough Wholegrain Crispy 100
                    // Topping Veggies 50
            try
            {
                string[] inputPizza = Console.ReadLine().Split();
                string pizzaName = inputPizza[1];
                string[] inputDough = Console.ReadLine().Split();
                string flourType = inputDough[1];
                string bakingTehnique = inputDough[2];
                int doughWeight = int.Parse(inputDough[3]);

                Dough dough = new Dough(flourType, bakingTehnique, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string inputTopping;
                while ((inputTopping = Console.ReadLine()) != "END")
                {
                    string[] info = inputTopping.Split();
                    string toppingType = info[1];
                    int toppingWeight = int.Parse(info[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
