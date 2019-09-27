using System;

namespace Farm
{
    public class Animal
    {
        public int Weight { get; set; }
        public int Age { get; set; }

        public void Eat()
        {
            Console.WriteLine("eating...");
        }
    }
}
