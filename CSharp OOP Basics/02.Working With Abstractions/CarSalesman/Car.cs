namespace CarSalesman
{
    public class Car
    {
        //model, engine, *weight and *color

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = "n/a"; // should display "n/a" if not available in creation; try string vs int
            this.Color = "n/a";
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        //Console.WriteLine($"{car.Model}:");
        //        Console.WriteLine($"  {car.Engine.Model}:");
        //        Console.WriteLine($"    Power: {car.Engine.Power}");
        //        Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
        //        Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
        //        Console.WriteLine($"  Weight: {car.Weight}");
        //        Console.WriteLine($"  Color: {car.Color}");

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine($"{this.Model}:")
        //        .AppendLine($"  {this.Engine}");
        //    if (this.Weight == 0)
        //    {
        //        sb.AppendLine($"  Weight: n/a");
        //    }
        //    else
        //    {
        //        sb.AppendLine($"  Weight: {this.Weight}");
        //    }
        //    sb.AppendLine($"  Color: {this.Color}");

        //    return sb.ToString().Trim();
        //}
    }
}
