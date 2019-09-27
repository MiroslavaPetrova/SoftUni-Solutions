using Farm.Animals;
using Farm.Factories;
using System;
using System.Collections.Generic;

namespace Farm.Core
{
    public class Engine
    {
        private AnimalFactory animalFactory;
        private List<Animal> animals;

        public Engine()
        {
            this.animalFactory = new AnimalFactory();
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            //Cat
            //Tom 12 Male

            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                try
                {
                    string animalType = input;

                    string[] animalInfo = Console.ReadLine().Split();

                    string name = animalInfo[0];
                    int age = int.Parse(animalInfo[1]);
                    string gender = string.Empty;

                    if (animalInfo.Length == 3)
                    {
                        gender = animalInfo[2];
                    }
                    
                    Animal animal = this.animalFactory.CreateAnimal(animalType, name, age, gender);
                    animals.Add(animal);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
                input = Console.ReadLine();
            }
            foreach (var animal in animals)
            {                                              
                Console.WriteLine(animal);
            }   
        }
    }
}
