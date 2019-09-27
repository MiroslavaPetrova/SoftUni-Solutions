using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IBirthable> allCreatures = new List<IBirthable>();

            string input = Console.ReadLine();
            // Citizen Pesho 22 9010101122 10/10/1990
            // Pet Sharo 13/11/2005
            // Robot MK-13 558833251

            while (input != "End")
            {
                string[] info = input.Split();

                if (info[0].ToLower() == "citizen")
                {
                    string name = info[1];
                    int age = int.Parse(info[2]);
                    string id = info[3];
                    string birthdate = info[4];
                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    allCreatures.Add(citizen);
                }
                else if(info[0].ToLower() == "pet")
                {
                    string name = info[1];
                    string birthdate = info[2];
                    Pet pet = new Pet(name, birthdate);
                    allCreatures.Add(pet);
                }
                input = Console.ReadLine();
            }
            string birthdayToCheck = Console.ReadLine();

            foreach (var creature in allCreatures.FindAll(c => c.Birthdate.EndsWith(birthdayToCheck)))
            {
                Console.WriteLine(creature.Birthdate);
            }
        }
    }
}
