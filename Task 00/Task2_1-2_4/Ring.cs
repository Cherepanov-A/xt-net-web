using System;

namespace Task2_1_2_4
{
    internal class Ring : Round
    {
        private int _outerRadius;
        public int OuterRadius
        {
            get => _outerRadius;
            set
            {
                if (value > 0 && value > Radius)
                {
                    _outerRadius = value;
                }
                else
                {
                    throw new ArgumentException("Outer radius can't be less, than 1 or inner radius", nameof(OuterRadius));
                }
            }
        }

        public int Radius
        {
            get => base.Radius;
            set
            {
                if (value > 0 && value < OuterRadius)
                {
                    base.Radius = value;
                }
                else
                {
                    throw new ArgumentException("Inner radius can't be less, than 1 or more, than outer radius", nameof(Radius));
                }
            }
        }

        public Ring(int x, int y, int radius, int outerRadius) : base(x, y, radius)
        {
            OuterRadius = outerRadius;
        }
        public double Area()
        {
            var inArea = base.Area();
            var outArea = Math.PI * OuterRadius * OuterRadius;
            return outArea - inArea;
        }

        public double LengthOfCircle()
        {
            var inLen = base.LengthOfCircle();
            var outLen = 2 * Math.PI * OuterRadius;
            return inLen + outLen;
        }
    }
}
