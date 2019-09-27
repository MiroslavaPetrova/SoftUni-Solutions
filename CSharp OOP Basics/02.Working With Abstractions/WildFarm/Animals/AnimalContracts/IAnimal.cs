using WildFarm.Foods;
using WildFarm.Foods.FoodContracts;

namespace WildFarm.Animals.AnimalContracts
{
    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; set; }

        int FoodEaten { get; set; }
        // If you try to give an animal a different type of food, it will not eat it and you should print:
        //"{AnimalType} does not eat {FoodType}!"
        //The weight of an animal will increase with every piece of food it eats, as follows:

        string ProduceSound();

        void FeedAnimal(IFood foodType);

    }
}
