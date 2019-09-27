using System;
using WildFarm.Foods;
using WildFarm.Foods.FoodContracts;

namespace WildFarm.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void FeedAnimal(IFood foodType)
        {
            if (foodType.GetType().Name != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType.GetType().Name}!");
            }

            this.Weight += 0.40 * foodType.Quantity;
            this.FoodEaten += foodType.Quantity;
        }

        public override string ProduceSound()
        {
            return $"Woof!";
        }
    }
}
