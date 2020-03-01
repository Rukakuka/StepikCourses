using System;

namespace MyPhotoshop
{
    public class Photo
    {
        public readonly int Width;
        public readonly int Height;
        private readonly Pixel[,] Pixels;
        public Photo(int width, int height)
        {
            if (width > 0)
                Width = width;
            else
                throw new Exception(string.Format("Wrong image width {0} (the value must be between more than 0)", width));

            if (height > 0)
                Height = height;
            else
                throw new Exception(string.Format("Wrong image width {0} (the value must be between more than 0)", height));

            Pixels = new Pixel[Width, Height];
        }
        public Pixel this[int x, int y]
        {
            get { return Pixels[x, y]; }
            set { Pixels[x, y] = value; }
        }
    }
}

