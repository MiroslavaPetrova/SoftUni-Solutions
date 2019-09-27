using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl2
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IIdentifiable> allCreatures = new List<IIdentifiable>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] info = input.Split();

                if (info.Length == 3)
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string id = info[2];

                    Citizen citizen = new Citizen(name, age, id);
                    allCreatures.Add(citizen);
                }
                else
                {
                    string model = info[0];
                    string id = info[1];

                    Robot robot = new Robot(model, id);
                    allCreatures.Add(robot);
                }
                input = Console.ReadLine();
            }
            string fakeId = Console.ReadLine();
            foreach (var creature in allCreatures.FindAll(c => c.Id.EndsWith(fakeId)))
            {
                Console.WriteLine(creature.Id);
            }
        }
    }
}
