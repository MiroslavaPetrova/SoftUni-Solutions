using System;
using System.Linq;
using System.Reflection;
using WildFarm.Animals.AnimalContracts;
using WildFarm.Factories.Contracts;

namespace WildFarm.Factories
{
    public class FelineFactory : IFelineFactory
    {
            //Tiger Typcho 167.7 Asia Bengal

        public IFeline CreateFeline(string felineType, string name, double weight, string livingRegion, string breed)
        {
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(f => f.Name == felineType);

            IFeline felineInstance = (IFeline)Activator.CreateInstance(type, new object[] { name, weight, livingRegion, breed });

            return felineInstance;
        }
    }
}
