using System;

namespace Farm
{
    public class Dog : Animal
    {
        public string Name { get; set; }

        public void Bark()
        {
            Console.WriteLine("barking...");
        }
    }
}
