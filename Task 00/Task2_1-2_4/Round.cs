using System;

namespace Task2_1_2_4
{
    public class Round : Circle
    {
        public Round(int x, int y, int radius) : base(x, y, radius) { }

        public virtual double Area()
        {
            var area = Math.PI * Radius * Radius;
            return area;
        }

        public override void Draw()
        {
            Console.WriteLine($"Type={GetType()}   X={X} Y={Y}   Radius={Radius}   Length={LengthOfCircle()}  Area={Area()}");
        }
    }
}
