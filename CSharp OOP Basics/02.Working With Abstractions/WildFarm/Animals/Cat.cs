using System;
using WildFarm.Foods.FoodContracts;

namespace WildFarm.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void FeedAnimal(IFood foodType)
        {
            if (foodType.GetType().Name != "Vegetable" && foodType.GetType().Name != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType.GetType().Name}!");
            }

            this.Weight += 0.30 * foodType.Quantity;
            this.FoodEaten += foodType.Quantity;
        }

        public override string ProduceSound()
        {
            return $"Meow";
        }
    }
}
