using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {

        public static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                //<Model> <FuelAmount> <FuelConsumptionFor1km>
                string[] info = Console.ReadLine().Split();
                string model = info[0];
                double fuelAmount = double.Parse(info[1]);
                double fuelConsumptionPerKm = double.Parse(info[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKm);

                cars.Add(model, car);
            }
            
            string input = Console.ReadLine();
            while (input != "End")
            {
                //Drive <CarModel>  <amountOfKm>
                string[] inputArgs = input.Split();
                string carModel = inputArgs[1];
                int distanceToTravel = int.Parse(inputArgs[2]);

                if (cars[carModel].CalculateDistance(distanceToTravel) == false)
                {
                    Console.WriteLine($"Insufficient fuel for the drive");
                }
               
                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} {car.Value.FuelAmount:f2} {car.Value.TravelledDistance}");
            }
        }
    }
}
