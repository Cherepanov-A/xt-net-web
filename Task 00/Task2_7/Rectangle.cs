using System;
using Task2_1_2_4;

namespace Task2_7
{
    internal class Rectangle: IDrawable
    {
        private int _width;
        private int _height;
        private readonly Point _point;
        public int Width
        {
            get => _width;
            set
            {
                if (value > 0)
                {
                    _width = value;
                }
                else
                {
                    throw new ArgumentException("Width can't be zero or less", nameof(Width));
                }
            }
        }

        public int Height
        {
            get => _height;
            set
            {
                if (value > 0)
                {
                    _height = value;
                }
                else
                {
                    throw new ArgumentException("Height can't be zero or less", nameof(Height));
                }
            }
        }

        public int X
        {
            get => _point.X;
            set => _point.X = value;
        }

        public int Y
        {
            get => _point.Y;
            set => _point.Y = value;
        }

        public Rectangle(int x, int y, int height, int width)
        {
            _point = new Point();
            X = x;
            Y = y;
            Height = height;
            Width = width;
        }

        public int Area()
        {
            int area = Height * Width;
            return area;
        }

        public int Perimeter()
        {
            int perimeter = (Height + Width) * 2;
            return perimeter;
        }

        public void Draw()
        {
            Console.WriteLine($"Type={GetType()}   X={X} Y={Y}   {Height} {Width}  Perimeter={Perimeter()}  Area={Area()}");
        }
    }
}
