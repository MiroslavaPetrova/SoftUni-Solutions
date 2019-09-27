using WildFarm.Foods;
using WildFarm.Foods.FoodContracts;

namespace WildFarm.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingsize)
            : base(name, weight, wingsize)
        {
        }

        public override void FeedAnimal(IFood foodType)
        {
            this.Weight += 0.35 * foodType.Quantity;
            this.FoodEaten += foodType.Quantity;
        }

        public override string ProduceSound()
        {
            return $"Cluck";
        }
    }
}
