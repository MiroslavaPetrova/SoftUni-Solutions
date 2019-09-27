using WildFarm.Foods.FoodContracts;

namespace WildFarm.Factories.Contracts
{
    public interface IFoodFactory
    {
        IFood CreateFood(string foodType, int quantity);
    }
}
