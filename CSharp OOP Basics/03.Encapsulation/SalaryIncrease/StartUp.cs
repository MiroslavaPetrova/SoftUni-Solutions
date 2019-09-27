
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
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] info = Console.ReadLine().Split();
                var person = new Person(info[0], 
                                            info[1], 
                                            int.Parse(info[2]), 
                                            decimal.Parse(info[3]));
                persons.Add(person);
            }
            decimal percentage = decimal.Parse(Console.ReadLine());
            persons.ForEach(p => p.IncreaseSalary(percentage));
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
