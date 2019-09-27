using System;
using WildFarm.Foods;
using WildFarm.Foods.FoodContracts;

namespace WildFarm.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void FeedAnimal(IFood foodType)
        {
            if (foodType.GetType().Name != "Vegetable" && foodType.GetType().Name != "Fruit")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType.GetType().Name}!");
            }

            this.Weight += 0.1 * foodType.Quantity;
            this.FoodEaten += foodType.Quantity;
        }

        public override string ProduceSound()
        {
            return $"Squeak";
        }
    }
}
