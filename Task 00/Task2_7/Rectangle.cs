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
        public int Width { get; set; }
        public int Height { get; set; }
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
