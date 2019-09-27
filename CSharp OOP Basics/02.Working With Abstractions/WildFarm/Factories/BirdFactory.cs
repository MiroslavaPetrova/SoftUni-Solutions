using System;
using System.Linq;
using System.Reflection;
using WildFarm.Animals.AnimalContracts;
using WildFarm.Factories.Contracts;

namespace WildFarm.Factories
{
    public class BirdFactory : IBirdFactory
    {
        public IBird CreateBird(string birdType, string name, double weight, int wingSize)
        {
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(b => b.Name == birdType);

            IBird birdInstance = (IBird)Activator.CreateInstance(type, new object [] {name, weight, wingSize });

            return birdInstance;
        }
    }
}
