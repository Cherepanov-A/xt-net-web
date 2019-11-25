using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_2_4
{
    class Triangle
    {
        private int a;
        private int b;
        private int c;
        public int A
        {
            get => a;
            set
            {
                if (value > 0 && value < b + c)
                {
                    a = value;
                }
                else
                {
                    throw new ArgumentException("Side can't be less than 1 or more than sum of other sides");
                }
            }
        }

        public int B
        {
            get => b;
            set
            {
                if (value > 0 && value < a + c)
                {
                    b = value;
                }
                else
                {
                    throw new ArgumentException("Side can't be less than 1 or more than sum of other sides");
                }
            }
        }

        public int C
        {
            get => c;
            set
            {
                if (value > 0 && value < a + b)
                {
                    c = value;
                }
                else
                {
                    throw new ArgumentException("Side can't be less than 1 or more than sum of other sides");
                }
            }
        }

        public Triangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            if (a < 1 && a > b + c || b < 1 && b > a + c || c < 1 && c > a + b)
            {
                throw new ArgumentException("Side can't be less than 1 or more than sum of other sides");
            }
        }
        public int Perimeter() => a + b + c;

        public double Area()
        {
            double halfP = (a + b + c) / 2;
            return Math.Sqrt(halfP * (halfP - a) * (halfP - b) * (halfP - c));
        }

    }
}
