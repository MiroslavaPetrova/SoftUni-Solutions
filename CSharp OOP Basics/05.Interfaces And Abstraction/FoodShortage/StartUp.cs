using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();

                string name = info[0];
                int age = int.Parse(info[1]);

                if (info.Length == 3)
                {
                    string group = info[2];
                    Rebel rebel = new Rebel(name, age, group);
                    buyers.Add(rebel);
                }
                else
                {
                    string id = info[2];
                    string birthdate = info[3];
                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    buyers.Add(citizen);
                }
                
            }
            string nameToCheck = Console.ReadLine();

            while (nameToCheck != "End")
            {
                foreach (var name in buyers.Where(b => b.Name == nameToCheck))
                {
                    name.BuyFood();
                }

                nameToCheck = Console.ReadLine();
            }
            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
