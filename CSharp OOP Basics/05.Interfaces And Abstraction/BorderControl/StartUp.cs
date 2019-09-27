using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp                            // 60/100 "print in order of input.. means "
    {                                               // use one LIST<IIDENTIFIABLE>
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();   
            List<Robot> robots = new List<Robot>();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] info = command.Split();

                if (info.Length == 3)
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string id = info[2];

                    Citizen citizen = new Citizen(name, age, id);
                    citizens.Add(citizen);
                }
                else
                {
                    string model = info[0];
                    string id = info[1];

                    Robot robot = new Robot(model, id);
                    robots.Add(robot);
                }
                command = Console.ReadLine();
            }
            string fakeId = Console.ReadLine();

            foreach (var citizen in citizens.FindAll(c => c.Id.EndsWith(fakeId)))
            {
                Console.WriteLine(citizen.Id);
            }
            foreach (var robot in robots.FindAll(r => r.Id.EndsWith(fakeId)))
            {
                Console.WriteLine(robot.Id);
            }
            
        }
    }
}
