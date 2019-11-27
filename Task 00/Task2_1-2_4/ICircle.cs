using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task2_1_2_4
{
    public interface ICircle
    {
        int X { get; set; }
        int Y { get; set; }
        int Radius { get; set; }

        double LengthOfCircle();
    }
}
