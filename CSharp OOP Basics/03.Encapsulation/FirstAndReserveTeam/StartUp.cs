using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            
            Team team = new Team("Mimi");
            
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
                team.AddPlayer(person);
            }
            Console.WriteLine();
            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
