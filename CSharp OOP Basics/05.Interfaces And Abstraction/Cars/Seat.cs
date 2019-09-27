using System.Collections.Generic;

namespace Cars
{
    public class Seat : ICar
    {
        public string Colour { get ; set ; }
        public string Model { get; set ; }

        public Seat(string colour, string model)
        {
            this.Colour = colour;
            this.Model = model;
        }

        public string Start()
        {
            return $"Engine start";
        }

        public string Stop()
        {
            return $"Breaaak!";      
        }

        public override string ToString()
        {
            return $"{Colour} Seat {Model}";
        }
    }
}
