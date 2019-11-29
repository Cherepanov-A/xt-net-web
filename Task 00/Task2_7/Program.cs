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
                IDrawable figure;
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
                            try
                            {
                                figure = new Line(xLn1, yLn1, xLn2, yLn2);
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                                break;
                            }
                            Console.WriteLine();
                            figure.Draw();
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
                        figure = new Circle(xCir, yCir, rCir);
                        Console.WriteLine();
                        figure.Draw();
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
                        figure = new Round(xRnd, yRnd, rRnd);
                        Console.WriteLine();
                        figure.Draw();
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
                        try
                        {
                            figure = new Ring(xRng, yRng, rInRng, rOutRng);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        Console.WriteLine();
                        figure.Draw();
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
                        figure = new Rectangle(xRec, yRec, height, width);
                        Console.WriteLine();
                        figure.Draw();
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
