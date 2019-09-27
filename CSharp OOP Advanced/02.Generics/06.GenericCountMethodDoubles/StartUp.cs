using System;
using System.Collections.Generic;

namespace GenericCountMethodDoubles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<double> items = new List<double>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                double line = double.Parse(Console.ReadLine());
                items.Add(line);
            }
            Box<double> box = new Box<double>(items);

            double elementToCompare = double.Parse(Console.ReadLine());
            int result = box.CompareTo(items, elementToCompare);

            Console.WriteLine(result);
        }
    }
}
