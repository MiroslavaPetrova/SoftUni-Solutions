using System;
namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double  consumptionPerKm;

        protected Vehicle(double fuelQuantity, double consumptionPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.ConsumptionPerKm = consumptionPerKm;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        public double ConsumptionPerKm
        {
            get { return consumptionPerKm; }
            set { consumptionPerKm = value; }
        }

        public void DistanceTravelled(double distance)
        {
            double fuelWasted = distance * this.ConsumptionPerKm;

            if (this.FuelQuantity >= fuelWasted)
            {
                this.FuelQuantity -= fuelWasted;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
