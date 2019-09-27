namespace CarSalesman
{
    public class Engine
    {
        //model, power, *displacement *efficiency

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = "n/a"; // should display "n/a" if not available in creation;
            this.Efficiency = "n/a";
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }
        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine($"  {this.Model}:")
        //        .AppendLine($"    Power: {this.Power}");
        //    if (this.Displacement == 0)
        //    {
        //        sb.AppendLine($"    Displacement: n/a");
        //    }
        //    else
        //    {
        //        sb.AppendLine($"    Displacement: {this.Displacement}");
        //    }
        //    sb.AppendLine($"    Efficiency: {this.Efficiency}");

        //    return sb.ToString().Trim();
        //}
    }
}
