using System;

namespace Task2_1_2_4
{
    public class Ring : Round
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

        public override int Radius
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
        public override double Area()
        {
            var inArea = base.Area();
            var outArea = Math.PI * OuterRadius * OuterRadius;
            return outArea - inArea;
        }

        public override double LengthOfCircle()
        {
            var inLen = base.LengthOfCircle();
            var outLen = 2 * Math.PI * OuterRadius;
            return inLen + outLen;
        }

        public override void Draw()
        {
            Console.WriteLine($"Type={GetType()}   X={X} Y={Y}   Inner radius={Radius} Outer radius={OuterRadius}  Length={LengthOfCircle()}  Area={Area()}");
        }
    }
}
