using WildFarm.Animals.AnimalContracts;
using WildFarm.Foods;
using WildFarm.Foods.FoodContracts;

namespace WildFarm.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }               

        public abstract string ProduceSound();

        public abstract void FeedAnimal(IFood foodType);

        //public override string ToString()
        //{
        //    return $"{this.ProduceSound()}\n{this.GetType().Name} [{this.Name}, {this.}, 2.3, Home, 4]";
        //}
    }
}
