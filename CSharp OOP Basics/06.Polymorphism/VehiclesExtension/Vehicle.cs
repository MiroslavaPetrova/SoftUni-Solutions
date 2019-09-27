using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double consumptionPerKm;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double consumptionPerKm, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.ConsumptionPerKm = consumptionPerKm;
        }

        public bool IsVehicleEmpty { get; set; }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }
                fuelQuantity = value;
            }
        }

        public double ConsumptionPerKm
        {
            get { return consumptionPerKm; }
            set { consumptionPerKm = value; }
        }

        public double TankCapacity
        {
            get => tankCapacity;
            set
            {
                tankCapacity = value;
            }
        }

        public virtual void DistanceTravelled(double distance)
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
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.TankCapacity < this.FuelQuantity + fuel)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += fuel; //added else
            }
            
            
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
