using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double consumptionPerKm, double tankCapacity)
            : base(fuelQuantity, consumptionPerKm, tankCapacity)
        {
        }

        public override void DistanceTravelled(double distance)
        {
            double currentFuelConsumption = this.ConsumptionPerKm;

            if (!IsVehicleEmpty)
            {
                currentFuelConsumption += 1.4;
            }

            double fuelWasted = distance * currentFuelConsumption;

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
    }
}
