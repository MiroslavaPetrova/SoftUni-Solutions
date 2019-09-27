using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
           
            string input = Console.ReadLine();

            while (input != "Beast!")             
            {
                try
                {
                    string animalType = input;
                    string[] info = Console.ReadLine().Split();

                    string name = info[0];
                    int age = 0;
                    string gender = info[2];
                    
                    if (!int.TryParse(info[1],out age) && info.Length < 3)

                    {
                        Console.WriteLine("Invalid input!");
                    }

                    if (animalType.ToLower() == "dog")
                    {
                        Dog dog = new Dog(animalType, name, age, gender);
                        animals.Add(dog);
                    }
                    else if (animalType.ToLower() == "frog")
                    {
                        Frog frog = new Frog(animalType, name, age, gender);
                        animals.Add(frog);
                    }
                    else if (animalType.ToLower() == "cat")
                    {
                        Cat cat = new Cat(animalType, name, age, gender);
                        animals.Add(cat);
                    }
                    else if (animalType.ToLower() == "kitten")
                    {
                        Kitten kitten = new Kitten(animalType, name, age, gender);
                        animals.Add(kitten);
                    }
                    else if (animalType.ToLower() == "tomcat")
                    {
                        Tomcat tomcat = new Tomcat(animalType, name, age, gender);
                        animals.Add(tomcat);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                catch (FormatException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                input = Console.ReadLine();
            }
            
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.AnimalType);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.Sound);
            }
        }
    }
}
