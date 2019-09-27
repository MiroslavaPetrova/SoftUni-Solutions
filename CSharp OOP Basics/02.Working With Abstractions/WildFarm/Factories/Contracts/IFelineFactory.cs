using WildFarm.Animals.AnimalContracts;

namespace WildFarm.Factories.Contracts
{
    public interface IFelineFactory
    {        
        IFeline CreateFeline(string felineType, string name, double weight, string livingRegion, string breed);        
    }
}
