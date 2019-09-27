using System.Collections.Generic;

namespace RawData
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, List<Tyre> tyres)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tyres = tyres;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public List<Tyre> Tyres { get; set; }
    }
}
