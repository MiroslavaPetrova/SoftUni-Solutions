using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                //“<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType> 
                //<Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>”
                string model = info[0];
                int engineSpeed = int.Parse(info[1]);
                int enginePower = int.Parse(info[2]);
                int cargoWeight = int.Parse(info[3]);
                string cargoType = info[4];

                List<Tire> tires = new List<Tire>();

                for (int j = 0; j < 4; j+=2)
                {
                    double tirePresure = double.Parse(info[5 + j]);
                    int tireAge = int.Parse(info[6 + j]);

                    Tire tire = new Tire(tireAge, tirePresure);
                    tires.Add(tire);
                }

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
            List<Car> resultCars = new List<Car>();

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                resultCars = cars
                    .Where(x => x.Cargo.CargoType == "fragile" 
                    && x.Tires.Any(s => s.Preasure < 1)).ToList();
            }
            else
            {
                resultCars = cars.Where(x => x.Cargo.CargoType == "flamable"
                 && x.Engine.Power > 250).ToList();
            }

            foreach (var car in resultCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
