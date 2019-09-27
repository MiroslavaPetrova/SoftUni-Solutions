using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            int  lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string [] info = Console.ReadLine().Split();
                Person person = new Person(info[0], info[1], int.Parse(info[2]));
                persons.Add(person);
            }
            persons.OrderBy(p => p.FirstName)
                .ThenBy(p => p.Age)
                .ToList()
                .ForEach(p => Console.WriteLine(p));
        }
    }
}
