using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] carInfo = Console.ReadLine().Split();

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKm = double.Parse(carInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKm);
                cars.Add(car);
            }

            //Drive<CarModel> < amountOfKm >”
            string driveCommand = Console.ReadLine();

            while (driveCommand != "End")
            {
                try
                {
                    string[] commandArgs = driveCommand.Split();

                    string modelToDrive = commandArgs[1];
                    int distanceToDrive = int.Parse(commandArgs[2]);

                    Car targetCar = cars.FirstOrDefault(c => c.Model == modelToDrive);

                    targetCar.CanDriveACar(distanceToDrive);
                }
                catch (Exception ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                driveCommand = Console.ReadLine();
            }
           
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
