using System;
using Task2_1_2_4;

namespace Task2_7
{
    internal class Line
    {
        private Point _point1;
        private Point _point2;
        public int X1 { get=>_point1.X; set=>_point1.X=value; }
        public int X2 { get => _point1.Y; set => _point1.Y = value; }
        public int Y1 { get => _point2.X; set => _point2.X = value; }
        public int Y2 { get => _point2.Y; set => _point2.Y = value; }

        public Line(int x1, int y1, int x2, int y2)
        {
            _point1=new Point();
            _point2=new Point();
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            if (X1==X2&&Y1==Y2)
            {
                throw new ArgumentException("Points can'be equal",$"{nameof(X1)}, {nameof(Y1)}, {nameof(X2)}, {nameof(Y2)}");
            }
        }
    }
}
