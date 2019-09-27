

namespace RawData
{
    public class Tire
    {
        private int age;
        private double preasure;

        public Tire(int age, double preasure)
        {
            this.Age = age;
            this.Preasure = preasure;
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public double Preasure
        {
            get { return preasure; }
            set { preasure = value; }
        }

    }
}
