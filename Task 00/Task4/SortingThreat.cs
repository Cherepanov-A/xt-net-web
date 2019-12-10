using System;

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
            Console.WriteLine("String sorting in thread 2");
            Print(mass);            
            var mass1 = CustomSort.Sort(mass, s);
            Console.WriteLine();
            Print(mass1);            
            Console.WriteLine();
            Done?.Invoke(this, new Thr2EventArgs("Thread 2 is done"));
            Console.WriteLine("Press any key to close thread 2");
            Console.ReadKey();
            Console.WriteLine("Thread 2 was closed");

        }

        internal static void Print<T>(T[] mass1)
        {
            foreach (var item in mass1)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}

