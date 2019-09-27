using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string [] inputArgs = Console.ReadLine().Split();
                //“<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType> 
                //<Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>”

                string model = inputArgs[0];
                int speed = int.Parse(inputArgs[1]);
                int power = int.Parse(inputArgs[2]);
                int weight = int.Parse(inputArgs[3]);
                string type = inputArgs[4];

                Engine engine = new Engine(speed, power);
                Cargo cargo = new Cargo(weight, type);

                List<Tyre> tyres = new List<Tyre>();

                for (int j = 0; j < 7; j += 2)
                {
                    double tyrePressure = double.Parse(inputArgs[5 + j]);
                    int tyreAge = int.Parse(inputArgs[6 + j]);

                    Tyre tyre = new Tyre(tyreAge, tyrePressure);
                    tyres.Add(tyre);
                }

                Car car = new Car(model, engine, cargo, tyres);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            List<Car> filteredCars = new List<Car>();

            if (command == "fragile")
            {
                filteredCars = cars
                            .Where(c => c.Cargo.Type == "fragile" && c.Tyres.Any(t => t.Pressure < 1))
                            .ToList();
            }
            else
            {
                filteredCars = cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250).ToList();
            }

            foreach (Car car in filteredCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
