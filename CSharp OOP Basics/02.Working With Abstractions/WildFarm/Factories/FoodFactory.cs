using System;
using System.Linq;
using System.Reflection;
using WildFarm.Factories.Contracts;
using WildFarm.Foods.FoodContracts;

namespace WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string foodType, int quantity)
        {
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == foodType);

            var foodInstance = (IFood)Activator.CreateInstance(type, quantity);

            return foodInstance;
        }
    }
}
