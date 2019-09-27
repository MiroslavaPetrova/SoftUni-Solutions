
namespace GenericCountMethodStrings
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> items = new List<string>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string line = Console.ReadLine();
                items.Add(line);
            }

            Box<string> box = new Box<string>(items);

            string elementToCompare = Console.ReadLine();
            int result = box.CompareTo(items, elementToCompare);

            Console.WriteLine(result);
        }
    }
}
