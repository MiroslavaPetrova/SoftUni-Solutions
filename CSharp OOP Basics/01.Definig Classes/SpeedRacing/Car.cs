using System;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double consumptionPerKm;
        private int travelledDistance;

        public Car(string model, double fuelAmount, double consumptionPerKm)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.ConsumptionPerKm = consumptionPerKm;
            this.TravelledDistance = 0;
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double ConsumptionPerKm
        {
            get { return consumptionPerKm; }
            set { consumptionPerKm = value; }
        }

        public int TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }
       
        public bool CalculateDistance(int distanceToTravel) 
        {
            double usedFuel = distanceToTravel * consumptionPerKm;

            if (usedFuel <= fuelAmount)
            {
                fuelAmount -= usedFuel;
                travelledDistance += distanceToTravel;
                return true;
               
            }
            return false;
        }
    }
}
