using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter a number of humans");
            //int.TryParse(Console.ReadLine(), out var n);
            //Lost.LastManStanding(n);

            //string s = "add add. pro m egg egg heat.";
            //WordFrequency.FCount(s);
            //Console.ReadLine();

            DynamicArray<int> da = new DynamicArray<int>(10);
            for (int i = 0; i < 10; i++)
            {
                da.Add(i);
            }
            Console.WriteLine(da[-33]);
            foreach (var i in da)
            {
                Console.WriteLine(i);
                if (i==100)
                {
                    return;
                }
            }
            

            //Console.WriteLine(-3%10);
            Console.ReadLine();
        }
    }
}
