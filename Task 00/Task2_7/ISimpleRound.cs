using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_1_2_4;

namespace Task2_7
{
    interface ISimpleRound
    {
        Point Point { get; set; }
        int Radius { get; set; }

        double LengthOfCircle();
    }
}
