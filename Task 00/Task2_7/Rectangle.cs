using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_1_2_4;

namespace Task2_7
{
    class Rectangle
    {
        private int _width;
        private int _height;
        public int Width
        {
            get => _width;
            set
            {
                if (value>0)
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
        public Point Point { get; set; }

        public Rectangle(int x, int y, int height, int width)
        {
            Point.X = x;
            Point.Y = y;
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
    }
}
