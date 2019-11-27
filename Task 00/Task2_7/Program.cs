using System;
using Task2_1_2_4;

namespace Task2_7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool check = true;
            while (check)
            {
                int choise = 0;
                Console.WriteLine("Choose a figure:");
                Console.WriteLine("1: Line");
                Console.WriteLine("2: Circle");
                Console.WriteLine("3: Round");
                Console.WriteLine("4: Ring");
                Console.WriteLine("5: Rectangle");
                Console.WriteLine("6: Quit");
                Console.WriteLine();
                choise = Validate(false);

                switch (choise)
                {
                    case 1:
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter first X");
                            int xLn1 = Validate(true);
                            Console.WriteLine("Enter first Y");
                            int yLn1 = Validate(true);
                            Console.WriteLine("Enter second X");
                            int xLn2 = Validate(true);
                            Console.WriteLine("Enter second Y");
                            int yLn2 = Validate(true);
                            Line line;
                            try
                            {
                                line = new Line(xLn1, yLn1, xLn2, yLn2);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                break;
                            }
                            Console.WriteLine();
                            Console.WriteLine(
                                $"Type={typeof(Line)}   X1={line.X1} Y1={line.Y1}   X2={line.X2} Y2={line.Y2}");
                            Console.WriteLine();
                            break;
                        }
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Enter X");
                        int xCir = Validate(true);
                        Console.WriteLine("Enter Y");
                        int yCir = Validate(true);
                        Console.WriteLine("Enter radius");
                        int rCir = Validate(false);
                        ICircle circle = new Round(xCir, yCir, rCir);
                        Console.WriteLine();
                        Console.WriteLine(
                            $"Type={typeof(ICircle)}   X={circle.X} Y={circle.Y}   Radius={circle.Radius}   Length={circle.LengthOfCircle()}");
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Enter X");
                        int xRnd = Validate(true);
                        Console.WriteLine("Enter Y");
                        int yRnd = Validate(true);
                        Console.WriteLine("Enter radius");
                        int rRnd = Validate(false);
                        var round = new Round(xRnd, yRnd, rRnd);
                        Console.WriteLine();
                        Console.WriteLine(
                            $"Type={typeof(Round)}   X={round.X} Y={round.Y}   Radius={round.Radius}   Length={round.LengthOfCircle()}  Area={round.Area()}");
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("Enter X");
                        int xRng = Validate(true);
                        Console.WriteLine("Enter Y");
                        int yRng = Validate(true);
                        Console.WriteLine("Enter radius");
                        int rInRng = Validate(false);
                        Console.WriteLine("Enter second radius");
                        int rOutRng = Validate(false);
                        var ring = new Ring(xRng, yRng, rInRng, rOutRng);
                        Console.WriteLine();
                        Console.WriteLine(
                            $"Type={typeof(Ring)}   X={ring.X} Y={ring.Y}   Inner radius={ring.Radius} Outer radius={ring.OuterRadius}  Length={ring.LengthOfCircle()}  Area={ring.Area()}");
                        Console.WriteLine();
                        break;
                    case 5:
                        Console.WriteLine();
                        Console.WriteLine("Enter X");
                        int xRec = Validate(true);
                        Console.WriteLine("Enter Y");
                        int yRec = Validate(true);
                        Console.WriteLine("Enter hight");
                        int height = Validate(false);
                        Console.WriteLine("Enter width");
                        int width = Validate(false);
                        var rectangle = new Rectangle(xRec, yRec, height, width);
                        Console.WriteLine();
                        Console.WriteLine(
                            $"Type={typeof(Rectangle)}   X={rectangle.X} Y={rectangle.Y}   {rectangle.Height} {rectangle.Width}  Perimeter={rectangle.Perimeter()}  Area={rectangle.Area()}");
                        Console.WriteLine();
                        break;
                    case 6:
                        Console.WriteLine();
                        check = false;
                        break;
                }
            }
            
        }
        
        private static int Validate(bool negative)
        {
            bool check = true;
            int val = 0;
            while (check)
            {
                if (negative)
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
                else
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
            }
            return val;
        }

    }
}
