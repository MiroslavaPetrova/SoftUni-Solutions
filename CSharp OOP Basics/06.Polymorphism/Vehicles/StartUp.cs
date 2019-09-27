using System;
using System.Collections.Generic;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            //Car {fuel quantity} {liters per km}
            string[] carInfo = Console.ReadLine().Split();
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carLitersPerKm = double.Parse(carInfo[2]);

            Vehicle car = new Car(carFuelQuantity, carLitersPerKm);
            vehicles.Add(car);

            string[] truckInfo = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckLitersPerKm = double.Parse(truckInfo[2]);

            Vehicle truck = new Truck(truckFuelQuantity, truckLitersPerKm);
            vehicles.Add(truck);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string vehicleType = input[1];
                double distanceOrFuelNeeded = double.Parse(input[2]);

                if (command == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        car.DistanceTravelled(distanceOrFuelNeeded);
                    }
                    else
                    {
                        truck.DistanceTravelled(distanceOrFuelNeeded);
                    }
                }
                else if(command == "Refuel")
                {
                    if (vehicleType == "Car")
                    {
                        car.Refuel(distanceOrFuelNeeded);
                    }
                    else
                    {
                        truck.Refuel(distanceOrFuelNeeded);
                    }
                }
            }
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }
    }
}
