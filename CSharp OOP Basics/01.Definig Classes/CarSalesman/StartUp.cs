using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)     // 100/100
        {
            List<Engine> engines = new List<Engine>();

            int enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                //“<Model> <Power> <Displacement> <Efficiency>
               
                string[] input = Console.ReadLine().Trim().Split();
                string model = input[0];
                int power = int.Parse(input[1]);

                Engine engine = new Engine(model, power);

                if (input.Length == 3)
                {
                    int displacement = 0;
                    if(int.TryParse(input[2], out displacement))
                    {
                        engine.Displacement = displacement; 
                    }
                    else
                    {
                        engine.Efficiency = input[2];
                    }
                }
                else if (input.Length == 4)
                {
                    engine.Displacement = int.Parse(input[2]); 
                    engine.Efficiency = input[3];
                    
                }
                engines.Add(engine);
            }
            List<Car> cars = new List<Car>();

            int carsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsCount; i++)
            {
                //“<Model> <Engine> <Weight> <Color>
                //FordMondeo DSL-13  ??? Purple
               
                string[] input = Console.ReadLine().Trim().Split();

                string model = input[0];
                string engineModel = input[1];
                Engine engine = engines.FirstOrDefault(e => e.Model == engineModel);

                Car car = new Car(model, engine);

                if (input.Length == 3)
                {
                    int parsedValue;
                    if (int.TryParse(input[2], out parsedValue))
                    {
                        car.Weight = parsedValue;
                    }
                    else
                    {
                        car.Color = input[2];
                    }
                }
                else if(input.Length == 4)
                {
                    car.Weight = int.Parse(input[2]);
                    car.Color = input[3];
                }
                cars.Add(car);
            }

            Print(cars);
        }

        private static void Print(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                if (car.Engine.Displacement == 0)
                {
                    Console.WriteLine($"    Displacement: n/a");
                }
                else
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                if (car.Weight == 0)
                {
                    Console.WriteLine($"  Weight: n/a");
                }
                else
                {
                    Console.WriteLine($"  Weight: {car.Weight}");
                }
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}
