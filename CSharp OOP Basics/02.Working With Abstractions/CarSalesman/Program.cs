using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();


            int countOfEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfEngines; i++)
            {
                //“<Model> <Power> <Displacement> <Efficiency>
                //V4-33 140 28 B
                string[] engineArgs = Console.ReadLine().Split();

                string engineModel = engineArgs[0];
                int power = int.Parse(engineArgs[1]);

                Engine engine = new Engine(engineModel, power);

                if (engineArgs.Length == 3)
                {
                    if (int.TryParse(engineArgs[2], out int result))
                    {
                        engine.Displacement = engineArgs[2];
                    }
                    else
                    {
                        engine.Efficiency = engineArgs[2];
                    }
                }
                else if (engineArgs.Length == 4)
                {
                    engine.Displacement = engineArgs[2];
                    engine.Efficiency = engineArgs[3];
                }

                engines.Add(engine);
            }

            int countOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCars; i++)
            {
                //Model> <Engine> <Weight> <Color
                //FordFocus V4-33 1300 Silver
                string[] carArgs = Console.ReadLine().Split();

                string carModel = carArgs[0];
                string engine = carArgs[1];

                Engine targetEngine = engines.FirstOrDefault(e => e.Model == engine);

                Car car = new Car(carModel, targetEngine);

                if (carArgs.Length == 3)
                {
                    if (int.TryParse(carArgs[2], out int result))
                    {
                        car.Weight = carArgs[2];
                    }
                    else
                    {
                        //VolkswagenGolf V4-33 Orange 
                        
                        car.Color = carArgs[2];
                    }
                }
                else if (carArgs.Length == 4)
                {
                    car.Weight = carArgs[2];
                    car.Color = carArgs[3];
                }

                cars.Add(car);
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
                //Console.WriteLine($"{car.Model}:");
                //Console.WriteLine($"  {car.Engine.Model}:");
                //Console.WriteLine($"    Power: {car.Engine.Power}");
                //Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                //Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                //Console.WriteLine($"  Weight: {car.Weight}");
                //Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}
