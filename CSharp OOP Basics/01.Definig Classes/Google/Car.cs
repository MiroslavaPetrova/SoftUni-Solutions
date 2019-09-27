using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Car
    {
        public string Model { get; }
        public int Speed { get; }

        public Car(string model, int speed)
        {
            Model = model;
            Speed = speed;
        }
    }
}
