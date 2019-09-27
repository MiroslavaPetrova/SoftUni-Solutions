using WildFarm.Foods.FoodContracts;

namespace WildFarm.Foods
{
    public abstract class Food : IFood
    {
        private int quantity;

        //Vegetable 4
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; }
    }
}
