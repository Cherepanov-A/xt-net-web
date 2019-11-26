using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_1_2_4;

namespace Task2_7
{
    class Line
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }

        public Line(int x1, int y1, int x2, int y2)
        {
            Point1.X = x1;
            Point1.Y = y1;
            Point2.X = x2;
            Point2.Y = y2;
        }
    }
}
