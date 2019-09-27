using Farm.Animals;
using System;
using System.Linq;
using System.Reflection;

namespace Farm.Factories
{
    public class AnimalFactory
    {
        public Animal CreateAnimal(string animalType, string name, int age, string gender)
        {
            string type = animalType.ToLower();

            switch (type)
            {
                case "dog":
                    Animal dog = new Dog(name, age, gender);
                    return dog;
                case "frog":
                    Animal frog = new Frog(name, age, gender);
                    return frog;
                case "cat":
                    Animal cat = new Cat(name, age, gender);
                    return cat;
                case "tomcat":
                    Animal tomcat = new Tomcat(name, age);
                    return tomcat;
                case "kitten":
                    Animal kitten = new Kitten(name, age);
                    return kitten;

                default: throw new ArgumentException("Invalid input!");
            }
        }
    }
}
