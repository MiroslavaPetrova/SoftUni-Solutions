namespace RawData
{
    public class Tyre
    {
        public Tyre(int age, double pressure)
        {
            this.Age = age;
            this.Pressure = pressure;
        }

        public int Age { get; set; }

        public double Pressure { get; set; }
    }
}
