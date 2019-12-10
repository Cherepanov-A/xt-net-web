using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class ICQ
    {
        private static int numberOfCycles = 10;
        internal  delegate int[] GetPositiveDel(int[] src);

        internal static void Run()
        {
            List<double> defaultMethod = new List<double>();
            List<double> delegatetMethod = new List<double>();
            List<double> anonMethod = new List<double>();
            List<double> lamMethod = new List<double>();
            List<double> linqMethod = new List<double>();
            Random rnd = new Random();
            int[] source = new int[100000000];
            for (int i = 0; i < source.Length; i++)
            {
                source[i] = rnd.Next(-111, 111);
            }
            for (int i = 0; i <= numberOfCycles; i++)
            {
                int[] a = PositiveGetter.GetPositive(source);
                defaultMethod.Add(PositiveGetter.Storage.TotalMilliseconds);

                Console.Write("-");

                GetPositiveDel gpd = PositiveGetter.GetPositive;
                int[] b = GetPosDel(source, gpd);
                delegatetMethod.Add(PositiveGetter.Storage.TotalMilliseconds);
                Console.Write("-");

                GetPositiveDel searcher = delegate
                {
                    int[] local = PositiveGetter.GetPositive(source);
                    return local;
                };
                int[] c = GetPosAnonDel(source, searcher);
                anonMethod.Add(PositiveGetter.Storage.TotalMilliseconds);
                Console.Write("-");

                int[] d = GetPosLamDel(source, ((src) => PositiveGetter.GetPositive(source)));
                lamMethod.Add(PositiveGetter.Storage.TotalMilliseconds);
                Console.Write("-");

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Restart();
                int[] e = GetPosLinDel(source);
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                linqMethod.Add(ts.TotalMilliseconds);
                Console.Write("-");
            }
            Console.WriteLine();
            Console.Write("Default Method: ");
            Console.WriteLine(Mid(defaultMethod));
            Console.Write("Delegate Method: ");
            Console.WriteLine(Mid(delegatetMethod));
            Console.Write("Anon Method: ");
            Console.WriteLine(Mid(anonMethod));
            Console.Write("Lamda Method: ");
            Console.WriteLine(Mid(lamMethod));
            Console.Write("Linq Method: ");
            Console.WriteLine(Mid(linqMethod));
            Console.ReadKey();
        }
        private static int[] GetPosDel(int[] source, GetPositiveDel gpd)
        {
            int[] a = gpd(source);
            return a;
        }
        private static int[] GetPosAnonDel(int[] source, GetPositiveDel gpd)
        {
            int[] a = gpd(source);
            return a;
        }
        private static int[] GetPosLamDel(int[] source, GetPositiveDel gpd)
        {
            int[] a = gpd(source);
            return a;
        }
        private static int[] GetPosLinDel(int[] source)
        {
            var a = from item in source
                where item > 0
                select item;
            return a.ToArray();
        }
        //private static void Print(TimeSpan ts)
        //{
        //    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        //        ts.Hours, ts.Minutes, ts.Seconds,
        //        ts.Milliseconds / 10);
        //    Console.WriteLine(elapsedTime);
        //}
        private static double Mid(List<double> ts)
        {
            double[] unsorted = ts.ToArray();
            Array.Sort(unsorted);
            return unsorted[numberOfCycles / 2];
        }
    }
}
