﻿using System;

namespace ClassBoxDataValidation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new Box(length, width, height);

                Console.WriteLine($"Surface Area - {box.GetSurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.GetLateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {box.GetVolume():f2}");

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
