using System;
using System.Linq;
using System.Reflection;
using WildFarm.Animals.AnimalContracts;
using WildFarm.Factories.Contracts;

namespace WildFarm.Factories
{
    public class MammalFactory : IMammalFactory
    {
        public IMammal CreateMammal(string mammalType, string name, double weight, string livingRegion)
        {
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(m => m.Name == mammalType);

            IMammal mammalInstance = (IMammal)Activator.CreateInstance(type, new object[] {name, weight, livingRegion });

            return mammalInstance;
        }
    }
}
