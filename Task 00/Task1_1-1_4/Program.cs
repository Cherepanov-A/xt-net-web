using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_1_1_4
{
    class Program
    {
        [Flags]
        private enum styles
        {
            none = 0,
            bold = 1,
            italic = 1 << 1,
            underline = 2 << 1
        }
        static void Main(string[] args)
        {
            bool quit = true;
            do
            {
                
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Rectangle");
                Console.WriteLine("2. Triangle");
                Console.WriteLine("3. Another triangle");
                Console.WriteLine("4. Cristmas tree");
                Console.WriteLine("5. Sum of numbers");
                Console.WriteLine("6. Font adjustment");
                Console.WriteLine("7. Quit");
                Console.WriteLine();
                int sw = Validate();
                Console.WriteLine();

                switch (sw)
                {
                    case 1:
                        Console.WriteLine("Enter side a");
                        int a = Validate();
                        Console.WriteLine("Enter side b");
                        int b = Validate();
                        Rectangle(a, b);
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter a number of strings");
                        int strNum = Validate();
                        Triangle(strNum);
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine("Enter a number of strings");
                        int anotherStrNum = Validate();
                        AnotherRectangle(anotherStrNum);
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine("Enter a number of triangles");
                        int ctNum = Validate();
                        ChristmasTree(ctNum);
                        Console.WriteLine();
                        break;
                    case 5:
                       Sum();
                        Console.WriteLine();
                        CleanUp();
                        break;
                    case 6:
                        Adjust();
                        break;
                    case 7:
                        quit = false;
                        break;
                }

            } while (quit);
        }

        private static void Adjust()
        {
            bool exit = true;
            styles fntStl = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            do
            {
                
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Bold");
                Console.WriteLine("2. Italic");
                Console.WriteLine("3. Underline");
                Console.WriteLine("4. Quit");
                Console.WriteLine();
                int styl = Validate();

                switch (styl)
                {
                    case 1:
                        fntStl = StileCheck(fntStl, styles.bold);
                        Console.WriteLine("Text style is: " + fntStl);
                        Console.WriteLine();
                        break;
                    case 2:
                        fntStl = StileCheck(fntStl, styles.italic);
                        Console.WriteLine("Text style is: " + fntStl);
                        Console.WriteLine();
                        break;
                    case 3:
                        fntStl = StileCheck(fntStl, styles.underline);
                        Console.WriteLine("Text style is: " + fntStl);
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.Clear();
                        exit = false;
                        break;
                }
            } while (exit);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        private static styles StileCheck(styles fntStl, styles style)
        {
            if (fntStl.HasFlag(style))
            {
                fntStl ^= style;
            }
            else
            {
                fntStl |= style;
            }

            return fntStl;
        }

        private static void Sum()
        {
            int[] arr = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                arr[i] = i + 1;
            }
            var result = arr.Where(num => (num % 5 == 0 || num % 3 == 0));//from num in arr where num % 5 == 0 || num % 3 == 0 select num;
            Console.WriteLine("Sum of numbers is " +result.Sum());

        }

        private static void ChristmasTree(int ctNum)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int x = 1; x <= ctNum; x++)
            {
                int j = 1;
                for (int i = x - 1; i >= 0; i--)
                {
                    Console.Write(new string(' ', (i + ctNum - x)));
                    Console.WriteLine(new string('*', j));
                    j += 2;
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            CleanUp();
        }


        private static void AnotherRectangle(int anotherStrNum)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int j = 1;
            for (int i = anotherStrNum - 1; i >= 0; i--)
            {
                Console.Write(new string(' ', i));
                Console.WriteLine(new string('*', j));
                j += 2;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            CleanUp();
        }

        private static void Triangle(int n)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine(new string('*', i));
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            CleanUp();
        }

        private static void CleanUp()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void Rectangle(int a, int b)
        {
            Console.WriteLine(a * b);
            CleanUp();
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
    }
}
