using System;

namespace Task2_7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            bool check = true;
            int choise=0;
            while (check)
            {
                Console.WriteLine("Choose a figure:");
                Console.WriteLine("1: Line");
                Console.WriteLine("2: Round");
                Console.WriteLine("3: Disk");
                Console.WriteLine("4: Ring");
                Console.WriteLine("5: Rectangle");
                Console.WriteLine("6: Quit");
                choise = Validate();
            }
            switch (choise)
            {
                case 1:
                {
                    Console.WriteLine("Enter first X");
                    int x1 = ValidateWhithNegative();
                    Console.WriteLine("Enter first Y");
                    int y1 = ValidateWhithNegative();
                    Console.WriteLine("Enter second X");
                    int x2 = ValidateWhithNegative();
                    Console.WriteLine("Enter second Y");
                    int y2 = ValidateWhithNegative();
                    var line = new Line(x1,y1,x2,y2);
                    Console.WriteLine($"{line.GetType()}   {line.Point1.X} {line.Point1.Y}   {line.Point2.X} {line.Point2.Y}");
                    break;
                }
                case 2: break;
                case 3: break;
                case 4: break;
                case 5: break;
            }
            Console.WriteLine();
            Console.WriteLine();
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
        private static int ValidateWhithNegative()
        {
            bool check = true;
            int val = 0;
            while (check)
            {
                if (int.TryParse(Console.ReadLine(), out val))
                {
                    check = false;
                }
                else
                {
                    Console.WriteLine("Enter integer value");
                }
            }
            return val;
        }
    }
}
