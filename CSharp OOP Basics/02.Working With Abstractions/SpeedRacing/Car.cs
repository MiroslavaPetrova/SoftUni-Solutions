using System;

namespace SpeedRacing
{
    public class Car
    {
        //model, fuel amount, fuel consumption for 1 kilometer and  traveled distance.
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKm;
        private int travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.TravelledDistance = 0;
        }

        public string Model { get; set; }
        
        public double FuelAmount { get; set; }
        
        public double FuelConsumptionPerKm { get; set; }

        public int TravelledDistance { get; set; }


        public void CanDriveACar(int distance)
        {
            double fuelNeeded = this.FuelConsumptionPerKm * distance;

            if (this.FuelAmount >= fuelNeeded)
            {
                this.FuelAmount -= fuelNeeded;
                this.TravelledDistance += distance;
            }
            else
            {
                throw new InvalidOperationException("Insufficient fuel for the drive");
            }
        }
    }
}
