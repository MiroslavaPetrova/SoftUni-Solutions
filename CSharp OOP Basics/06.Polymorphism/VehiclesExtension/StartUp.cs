using System;
using System.Collections.Generic;

namespace VehiclesExtension
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            //Vehicle {initial fuel quantity} {liters per km} {tank capacity}
            string[] carInfo = Console.ReadLine().Split();
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carLitersPerKm = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            Vehicle car = new Car(carFuelQuantity, carLitersPerKm, carTankCapacity);
            vehicles.Add(car);

            string[] truckInfo = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckLitersPerKm = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            Vehicle truck = new Truck(truckFuelQuantity, truckLitersPerKm, truckTankCapacity);
            vehicles.Add(truck);

            string[] busInfo = Console.ReadLine().Split();
            double busFuelQuantity = double.Parse(busInfo[1]);
            double busLitersPerKm = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            Vehicle bus = new Bus(busFuelQuantity, busLitersPerKm, busTankCapacity);
            vehicles.Add(bus);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string vehicleType = input[1];
                double amount = double.Parse(input[2]);

                if (command == "Refuel")
                {
                    if (vehicleType == "Car")
                    {
                        car.Refuel(amount);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(amount);
                    }
                    else if (vehicleType == "Bus")
                    {
                        bus.Refuel(amount);
                    }
                }
                else if (command == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        car.DistanceTravelled(amount);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.DistanceTravelled(amount);
                    }
                    else if (vehicleType == "Bus")
                    {
                        bus.IsVehicleEmpty = false;
                        bus.DistanceTravelled(amount);
                    }
                }
                else if (command == "DriveEmpty")
                {
                    bus.IsVehicleEmpty = true;
                    bus.DistanceTravelled(amount);
                }
            }
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
