using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person person = new Person("Michael", 34);
            Console.WriteLine(person.ToString());

            Person anotherPerson = new Person();
            anotherPerson.Name = "Pesho";
            anotherPerson.Age = 20;

            Console.WriteLine(anotherPerson.ToString());
        }
    }
}
