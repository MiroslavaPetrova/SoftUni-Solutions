using WildFarm.Animals.AnimalContracts;

namespace WildFarm.Animals
{
    public abstract class Mammal : Animal, IMammal
    {
        //Mouse Jerry 0.5 Anywhere
        protected Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; }

        public override string ToString()
        {
            return //$"{this.ProduceSound()}\n" +
                $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
