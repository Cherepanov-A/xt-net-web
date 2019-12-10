using System;
using System.Diagnostics;
using System.Linq;

namespace Task4
{
    class PositiveGetter
    {
        public static TimeSpan Storage { get; private set; }
        public static int[] GetPositive(int[] source)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Restart();
            int[] result = source.Where(item => item > 0).ToArray();
            stopWatch.Stop();
            Storage = stopWatch.Elapsed;
            return result;            
        }
    }
}
