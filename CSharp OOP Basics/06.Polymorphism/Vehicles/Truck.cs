using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double consumptionPerKm)
            : base(fuelQuantity, consumptionPerKm)
        {
            this.ConsumptionPerKm += 1.6;
        }

        public override void Refuel(double fuel)
        {
            this.FuelQuantity += (fuel - (fuel * 0.05));
        }
    }
}
