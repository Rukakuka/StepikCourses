using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public struct Pixel
    {
        private double red;
        private double green;
        private double blue;
        public double R
        {
            get { return red; }
            set
            {
                red = CheckBoundaries(value);
            }
        }
        public double G
        {
            get { return green; }
            set
            {
                green = CheckBoundaries(value);
            }
        }
        public double B
        {
            get { return blue; }
            set
            {
                blue = CheckBoundaries(value);
            }
        }
        public Pixel(double Red, double Green, double Blue)
        {
            red = green = blue = 0;
            R = Red;
            G = Green;
            B = Blue;
        }
        public double CheckBoundaries(double colorChannel)
        {
            if (colorChannel < 0 || colorChannel > 1)
                throw new Exception(string.Format("Wrong color channel value {0} (the value must be between 0 and 1)", colorChannel));
            return colorChannel;
        }
        public static double Trim(double colorChannel)
        {
            if (colorChannel < 0)
            {
                return 0;
            }
            if (colorChannel > 1)
            {
                return 1;
            }
            return colorChannel;
        }
        public static Pixel Trim(Pixel px)
        {
            return new Pixel
            {
                R = Pixel.Trim(px.R),
                G = Pixel.Trim(px.G),
                B = Pixel.Trim(px.B)
            };
        }
        public static Pixel operator* (Pixel pixel, double scaling)
        {
            return new Pixel
            {
                R = Trim(pixel.R * scaling),
                G = Trim(pixel.G * scaling),
                B = Trim(pixel.B * scaling)
            };            
        }
        public static Pixel operator *(double scaling, Pixel pixel)
        {
            return pixel * scaling;
        }
    }
}
