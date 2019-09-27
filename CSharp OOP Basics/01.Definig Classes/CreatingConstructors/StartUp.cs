using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person first = new Person();
            //first.Age = 13;
            Console.WriteLine(first.ToString());
        }
    }
}
