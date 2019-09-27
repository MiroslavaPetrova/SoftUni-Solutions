using System;
using System.Collections.Generic;
using WildFarm.Animals.AnimalContracts;
using WildFarm.Factories;
using WildFarm.Factories.Contracts;
using WildFarm.Foods.FoodContracts;

namespace WildFarm.Core
{
    public class Engine
    {
        private readonly IFelineFactory felineFactory;
        private readonly IMammalFactory mammalFactory;
        private readonly IBirdFactory birdFactory;
        private readonly IFoodFactory foodFactory;
        private ICollection<IAnimal> animals;
        private IAnimal animal;

        public Engine()
        {
            this.felineFactory = new FelineFactory();
            this.mammalFactory = new MammalFactory();
            this.birdFactory = new BirdFactory();
            this.foodFactory = new FoodFactory();
            this.animals = new List<IAnimal>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                try
                {
                    //• Felines - "{Type} {Name} {Weight} {LivingRegion} {Breed}";
                    //•	Birds - "{Type} {Name} {Weight} {WingSize}";
                    //•	Mice and Dogs - "{Type} {Name} {Weight} {LivingRegion}";

                    // Cat Pesho 1.1 Home Persian
                    // Vegetable 4
                    // End

                    string[] animalArgs = input.Split();
                    string[] foodArgs = Console.ReadLine().Split();

                    string animalType = animalArgs[0];
                    string name = animalArgs[1];
                    double weight = double.Parse(animalArgs[2]);

                    if (animalType == "Cat" || animalType == "Tiger")
                    {
                        string livingRegion = animalArgs[3];
                        string breed = animalArgs[4];

                        animal = (IAnimal)this.felineFactory.CreateFeline(animalType, name, weight, livingRegion, breed);
                    }
                    else if (animalType == "Dog" || animalType == "Mouse")
                    {
                        //Dog Doncho 500 Street
                        string livingRegion = animalArgs[3];
                        animal = (IAnimal)this.mammalFactory.CreateMammal(animalType, name, weight, livingRegion);
                    }
                    else if (animalType == "Owl" || animalType == "Hen")
                    {
                        int wingSize = int.Parse(animalArgs[3]);
                        animal = (IAnimal)this.birdFactory.CreateBird(animalType, name, weight, wingSize);
                    }



                    string foodType = foodArgs[0];
                    int quantity = int.Parse(foodArgs[1]);
                    IFood food = this.foodFactory.CreateFood(foodType, quantity);

                    animals.Add(animal);
                    Console.WriteLine(animal.ProduceSound());
                    animal.FeedAnimal(food);

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
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
