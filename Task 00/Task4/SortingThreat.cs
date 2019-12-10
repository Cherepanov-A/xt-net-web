using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task4
{
    internal class SortingThreat
    {
        internal event EventHandler<Thr2EventArgs> Done;

        internal void SortStart()
        {
            Console.WriteLine();
            Done?.Invoke(this, new Thr2EventArgs("Thread 2 is Start"));
            Sort<string> s = CustomSort.CustomEqual;
            string[] mass = { "aabb", "aaab", "cbbb", "s0", "sfdsds6" };
            var mass1 = CustomSort.Sort(mass, s);
            Console.WriteLine();
            foreach (var item in mass1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Done?.Invoke(this, new Thr2EventArgs("Thread 2 is done"));
            Console.WriteLine("Press any key to close thread 2");
            Console.ReadKey();
            Console.WriteLine("Thread 2 was closed");
           
        }
    }
}

