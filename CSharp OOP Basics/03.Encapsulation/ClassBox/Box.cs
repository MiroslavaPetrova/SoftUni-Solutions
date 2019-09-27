using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public double GetSurfaceArea()
        {
            return 2 * (Length * Height + Width * Height + Length * Width);
        }
        public double GetLateralSurfaceArea()
        {
            return 2 * (Length * Height + Width * Height);
        }
        public double GetVolume()
        {
            return Length * Width * Height;
        }
    }
}
