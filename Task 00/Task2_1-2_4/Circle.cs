using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_2_4
{
    public class Circle:IDrawable
    {
        private readonly Point _point;
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
        public virtual int Radius
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
        public Circle(int x, int y, int radius)
        {
            _point = new Point();
            X = x;
            Y = y;
            _radius = radius;
        }

       

        public virtual double LengthOfCircle()
        {
            var len = 2 * Math.PI * _radius;
            return len;
        }

        public virtual void Draw()
        {
            Console.WriteLine($"Type={GetType()}   X={X} Y={Y}   Radius={Radius}   Length={LengthOfCircle()}");
        }
    }
}
