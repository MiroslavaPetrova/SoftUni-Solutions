using WildFarm.Animals.AnimalContracts;

namespace WildFarm.Factories.Contracts
{
    public interface IBirdFactory
    {
        IBird CreateBird(string birdType, string name, double weight, int wingSize);
    }
}
