using System;
using System.Collections.Generic;
using System.Linq;

namespace RectangleIntersection
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Rectangle> rectangles = new List<Rectangle>();

            int [] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rectanglesCount = commands[0];
            int intersections = commands[1];

            for (int i = 0; i < rectanglesCount; i++)
            {
                string[] info = Console.ReadLine().Split();
                string name = info[0];
                double width = double.Parse(info[1]);
                double height= double.Parse(info[2]);
                double x = double.Parse(info[3]);
                double y = double.Parse(info[4]);

                Rectangle rectangle = new Rectangle(name, width, height, x, y);
                rectangles.Add(rectangle);
            }
            for (int j = 0; j < intersections; j++)
            {
                string[] input = Console.ReadLine().Split();
                string firstId = input[0];
                string secondId = input[1];

                Rectangle firstRectangle = rectangles.FirstOrDefault(r => r.Id == firstId);
                Rectangle secondRectangle = rectangles.FirstOrDefault(r => r.Id == secondId);

                if (firstRectangle.Intersect(secondRectangle))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}
