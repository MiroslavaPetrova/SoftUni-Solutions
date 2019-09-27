using WildFarm.Animals.AnimalContracts;

namespace WildFarm.Factories.Contracts
{
    public interface IMammalFactory
    {
        IMammal CreateMammal(string mammalType, string name, double weight, string livingRegion);
    }
}
