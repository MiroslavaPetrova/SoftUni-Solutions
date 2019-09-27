namespace StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            SortedSet<Person> peopleByName = new SortedSet<Person>(new NameComparisson());
            SortedSet<Person> peopleByAge = new SortedSet<Person>(new AgeComparisson());

            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personInfo = Console.ReadLine().Split();
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);

                peopleByName.Add(person);
                peopleByAge.Add(person);
            }

            Console.WriteLine(string.Join("\n", peopleByName));
            Console.WriteLine(string.Join("\n", peopleByAge));
        }
    }
}
