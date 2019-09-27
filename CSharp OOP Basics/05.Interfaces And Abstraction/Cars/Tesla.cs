namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public string Colour { get; set; }
        public string Model { get; set; }
        public int Battery { get; set; }

        public Tesla(string colour, string model, int battery)
        {
            this.Colour = colour;
            this.Model = model;
            this.Battery = battery;   
        }
        public string Start()
        {
            return $"Engine start";
        }

        public string Stop()
        {
            return $"Breaaak!";
        }

        public override string ToString()
        {
            return $"{Colour} Tesla {Model} with {Battery} Batteries";
        }
    }
}
