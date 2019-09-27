namespace CustomList
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> customList = new List<string>();
            Box<string> box = new Box<string>(customList);
            string command = Console.ReadLine();

            while (command != "END")
            {
                string action = command.Split()[0];

                switch (action)
                {
                    case "Add":
                        string elementToAdd = command.Split()[1];
                        box.Add(elementToAdd);
                        break;
                    case "Remove":
                        int index = int.Parse(command.Split()[1]);
                        box.Remove(index);
                        break;
                    case "Contains":
                        string element = command.Split()[1];
                        Console.WriteLine(box.Contains(element));
                        break;
                    case "Swap":
                        int index1 = int.Parse(command.Split()[1]);
                        int index2 = int.Parse(command.Split()[2]);
                        box.Swap(index1, index2);
                        break;
                    case "Greater":
                        string elementToCheck = command.Split()[1];
                        Console.WriteLine(box.CountGreaterThan(elementToCheck));
                        break;
                    case "Max":
                        Console.WriteLine(box.Max());
                        break;
                    case "Min":
                        Console.WriteLine(box.Min());
                        break;
                    case "Print":
                        box.Print();
                        break;
                    case "Sort":
                        box.Sort(customList);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
