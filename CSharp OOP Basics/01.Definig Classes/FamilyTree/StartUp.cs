using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTree
{
    public class StartUp
    {
        static List<Person> persons;
        static List<string> relationships; //to store not filtered information
                                           // Penka Pesheva - 23/5/1980               

        public static void Main(string[] args)
        {
            persons = new List<Person>();
            relationships = new List<string>();

            string mainPersonInfo = Console.ReadLine();

            string input = Console.ReadLine();
            while (input != "End")
            {
                if (!input.Contains("-"))
                {
                    AddMember(input);
                }
                else
                {
                    relationships.Add(input); // not filtered information
                }
             
                input = Console.ReadLine();
            }
            foreach (var membersInfo in relationships)
            {
                string[] inputArgs = membersInfo
                    .Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Person parent = GetPerson(inputArgs[0]);
                Person child = GetPerson(inputArgs[1]);


                if (!parent.Children.Contains(child))
                {
                    parent.Children.Add(child);
                }
                if (!child.Parents.Contains(parent))
                {
                    child.Parents.Add(parent);
                }
            }
            Print(mainPersonInfo);
        }

        private static void Print(string mainPersonInfo)
        {
            Person mainPerson = GetPerson(mainPersonInfo);

            Console.WriteLine($"{mainPerson.Name} {mainPerson.Birthday}");
            Console.WriteLine("Parents:");

            foreach (var parent in mainPerson.Parents)
            {
                Console.WriteLine($"{parent.Name} {parent.Birthday}");
            }
            Console.WriteLine($"Children:");
            foreach (var child in mainPerson.Children)
            {
                Console.WriteLine($"{child.Name} {child.Birthday}");
            }
        }

        private static Person GetPerson(string input)
        {
            if (input.Contains("/"))
            {
                return persons.FirstOrDefault(p => p.Birthday == input);
            }
            return persons.FirstOrDefault(p => p.Name == input);
        }

        private static void AddMember(string input)
        {
            //Pesho Peshev 23/5/1980
            string[] info = input.Split();
            string name = info[0] + " " + info[1];
            string birthday = info[2];

            Person person = new Person(name, birthday);
            persons.Add(person);
        }
    }
}
