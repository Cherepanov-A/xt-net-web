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
            DynamicArray<int> da = new DynamicArray<int>();
            CycledDynamicArray<int> cda = new CycledDynamicArray<int>(10);
            for (int i = 0; i < 10; i++)
            {
                cda.Add(i);
                da.Add(i);
            }
            Console.WriteLine(cda[-33]);
            int c = 0;
            foreach (var i in cda)
            {
                Console.WriteLine(i);
                c++;
                if (c==100)
                {
                    break;
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            foreach (var i in da)
            {
                Console.WriteLine(i);
                
            }


            //Console.WriteLine(-3%10);
            Console.ReadLine();
        }
    }
}
