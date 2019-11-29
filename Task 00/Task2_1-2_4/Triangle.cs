using System;

namespace Task2_1_2_4
{
    internal class Triangle : IDrawable
    {
        private int _a;
        private int _b;
        private int _c;
        public int A
        {
            get => _a;
            set
            {
                if (value > 0 && value < _b + _c)
                {
                    _a = value;
                }
                else
                {
                    throw new ArgumentException("Side can't be less than 1 or more than sum of other sides", nameof(A));
                }
            }
        }
        public int B
        {
            get => _b;
            set
            {
                if (value > 0 && value < _a + _c)
                {
                    _b = value;
                }
                else
                {
                    throw new ArgumentException("Side can't be less than 1 or more than sum of other sides", nameof(B));
                }
            }
        }
        public int C
        {
            get => _c;
            set
            {
                if (value > 0 && value < _a + _b)
                {
                    _c = value;
                }
                else
                {
                    throw new ArgumentException("Side can't be less than 1 or more than sum of other sides", nameof(C));
                }
            }
        }
        public Triangle(int a, int b, int c)
        {
            this._a = a;
            this._b = b;
            this._c = c;
            if (a < 1 && a > b + c)
            {
                throw new ArgumentException("Side can't be less than 1 or more than sum of other sides", nameof(a));
            }
            if (b < 1 && b > a + c)
            {
                throw new ArgumentException("Side can't be less than 1 or more than sum of other sides", nameof(b));
            }
            if (c < 1 && c > a + b)
            {
                throw new ArgumentException("Side can't be less than 1 or more than sum of other sides", nameof(c));
            }

        }
        public int Perimeter() => _a + _b + _c;

        public double Area()
        {
            double halfP = (_a + _b + _c) / 2.0;
            double result = Math.Sqrt(halfP * (halfP - _a) * (halfP - _b) * (halfP - _c));
            return result;
        }

        public void Draw()
        {
            Console.WriteLine($"Type={GetType()}   A={A} B={B} C={C}   Perimeter={Perimeter()}  Area={Area()}");
        }
    }
}
