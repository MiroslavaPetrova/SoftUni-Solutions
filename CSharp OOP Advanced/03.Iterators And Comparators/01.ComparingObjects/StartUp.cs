namespace ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] personInfo = input.Split();

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                string town = personInfo[2];

                Person person = new Person(name, age, town);

                people.Add(person);

                input = Console.ReadLine();
            }

            int indexToCompare = int.Parse(Console.ReadLine()) - 1;
            Person personToCompare = people[indexToCompare];

            int samePeople = people.Count(p => p.CompareTo(personToCompare) == 0);
           
            if (samePeople > 1)
            {
                Console.WriteLine($"{samePeople} {people.Count - samePeople} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
