using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_2_4
{
    class Round
    {
        private int x;
        private int y;
        private int radius;
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius
        {
            get => radius;
            set
            {
                if (value > 0)
                {
                    radius = value;
                }
                else
                {
                    throw new ArgumentException("Radius can't be zero or less");
                }
            }
        }
        public Round(int x, int y, int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }
        public double Area() => Math.PI * radius * radius;

        public double LengthOfCircle() => 2 * Math.PI * radius;
    }
}
