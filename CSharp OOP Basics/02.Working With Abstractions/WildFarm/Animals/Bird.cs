using WildFarm.Animals.AnimalContracts;

namespace WildFarm.Animals
{
    public abstract class Bird : Animal, IBird
    {
        //Owl Toncho 2.5 30

        protected Bird(string name, double weight, double wingsize) 
            : base(name, weight)
        {
            this.WingSize = wingsize;
        }

        public double WingSize { get; }

        public override string ToString()
        {
            return //$"{this.ProduceSound()}\n" +
                $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}