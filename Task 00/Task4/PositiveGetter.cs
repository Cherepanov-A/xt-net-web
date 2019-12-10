using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class PositiveGetter
    {
        public static TimeSpan Storage { get; private set; }
        public static int[] GetPositive(int[] source)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Restart();
            stopWatch.Stop();
            Storage = stopWatch.Elapsed;
            //Print(ts);
            return source.Where(item => item > 0).ToArray();
        }
    }
}
