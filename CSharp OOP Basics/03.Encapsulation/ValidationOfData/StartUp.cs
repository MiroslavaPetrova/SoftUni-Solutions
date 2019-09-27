using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                List<Person> people = new List<Person>();

                int n = int.Parse(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    string[] info = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string firstName = info[0];
                    string lastName = info[1];
                    int age = int.Parse(info[2]);
                    decimal salary = decimal.Parse(info[3]);

                    Person person = new Person(firstName, lastName, age, salary);
                    people.Add(person);
                }
                decimal percentage = decimal.Parse(Console.ReadLine());
                people.ForEach(p => p.IncreaseSalary(percentage));

                foreach (var person in people)
                {
                    Console.WriteLine(person.ToString());
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
