using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double consumptionPerKm)
            : base(fuelQuantity, consumptionPerKm)
        {
            this.ConsumptionPerKm += 0.9;
        }
    }
}
