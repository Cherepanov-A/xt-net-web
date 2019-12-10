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
            bool quit = true;
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Lost");
                Console.WriteLine("2. Word Frequency");
                Console.WriteLine("3. Dynamic array demo");
                Console.WriteLine("4. Quit");
                Console.WriteLine();
                int sw = Validate();
                Console.WriteLine();
                switch (sw)
                {
                    case 1:
                        Console.WriteLine("Enter a number of humans");
                        int n = Validate();
                        Lost.LastManStanding(n);
                        CleanUp();
                        break;
                    case 2:
                        Console.WriteLine("Enter a text whith whitespase or dot splitters");
                        string text = Console.ReadLine();
                        Console.WriteLine();
                        WordFrequency.FCount(text);
                        CleanUp();
                        break;
                    case 3:
                        Console.WriteLine("Dynamic array demo.");
                        DynamicArray<int> da = new DynamicArray<int>();
                        CycledDynamicArray<int> cda = new CycledDynamicArray<int>(10);
                        for (int i = 0; i < 10; i++)
                        {
                            cda.Add(i);
                            da.Add(i);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Foreach iteration on 10 items dynamic array.");
                        foreach (var i in da)
                        {
                            Console.Write(i + " ");
                        }
                        Console.WriteLine(Environment.NewLine);
                        int c = 0;
                        Console.WriteLine("Foreach iteration on 10 items cycled array, with 100 iterations limit.");
                        foreach (var i in cda)
                        {
                            Console.Write(i + " ");
                            c++;
                            if (c == 100)
                            {
                                break;
                            }
                        }
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine($"Access by index = -33: {cda[-33]}");
                        CleanUp();
                        break;
                    case 4:
                        quit = false;
                        break;
                }
            } while (quit);
        }
        private static int Validate()
        {
            bool check = true;
            int val = 0;
            while (check)
            {
                if (int.TryParse(Console.ReadLine(), out val) && val > 0)
                {
                    check = false;
                }
                else
                {
                    Console.WriteLine("Enter positive, integer value");

                }
            }
            return val;
        }
        private static void CleanUp()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
