using System;

namespace Task2_1_2_4
{
    public class Round:ICircle
    {
        private Point _point;
        private int _radius;

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
        public int Radius
        {
            get => _radius;
            set
            {
                if (value > 0)
                {
                    _radius = value;
                }
                else
                {
                    throw new ArgumentException("Radius can't be zero or less", nameof(Radius));
                }
            }
        }
        public Round(int x, int y, int radius)
        {
            _point = new Point();
            X = x;
            Y = y;
            Radius = radius;
        }

        public double Area()
        {
            var area = Math.PI * _radius * _radius;
            return area;
        }

        public double LengthOfCircle()
        {
            var len = 2 * Math.PI * _radius;
            return len;
        }
    }
}
