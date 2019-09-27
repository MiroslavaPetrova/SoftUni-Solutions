using System;
using WildFarm.Foods;
using WildFarm.Foods.FoodContracts;

namespace WildFarm.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingsize)
            : base(name, weight, wingsize)
        {
        }

        public override void FeedAnimal(IFood foodType)
        {
            if (foodType.GetType().Name != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType.GetType().Name}!");
            }

            this.Weight += 0.25 * foodType.Quantity;
            this.FoodEaten += foodType.Quantity;
        }

        public override string ProduceSound()
        {
            return $"Hoot Hoot";
        }
    }
}
