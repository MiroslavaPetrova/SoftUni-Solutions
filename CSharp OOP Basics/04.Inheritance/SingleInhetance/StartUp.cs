using System;

namespace Farm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dog dog = new Dog();

            dog.Age = 45;
            dog.Name = "Toto";
            dog.Weight = 7;
            dog.Eat();
            dog.Bark();
            Console.WriteLine(dog.Weight);
            Console.WriteLine(dog.Name);
            Console.WriteLine(dog.Age);
        }
    }
}
