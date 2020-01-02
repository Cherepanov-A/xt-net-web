using System;
using Task2_1_2_4;
using Other;


namespace Task2_7
{
    public class Program
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
                choise = Tools.Validate(false);
                IDrawable figure;
                switch (choise)
                {
                    case 1:
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter first X");
                            int xLn1 = Tools.Validate(true);
                            Console.WriteLine("Enter first Y");
                            int yLn1 = Tools.Validate(true);
                            Console.WriteLine("Enter second X");
                            int xLn2 = Tools.Validate(true);
                            Console.WriteLine("Enter second Y");
                            int yLn2 = Tools.Validate(true);
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
                        int xCir = Tools.Validate(true);
                        Console.WriteLine("Enter Y");
                        int yCir = Tools.Validate(true);
                        Console.WriteLine("Enter radius");
                        int rCir = Tools.Validate(false);
                        figure = new Circle(xCir, yCir, rCir);
                        Console.WriteLine();
                        figure.Draw();
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Enter X");
                        int xRnd = Tools.Validate(true);
                        Console.WriteLine("Enter Y");
                        int yRnd = Tools.Validate(true);
                        Console.WriteLine("Enter radius");
                        int rRnd = Tools.Validate(false);
                        figure = new Round(xRnd, yRnd, rRnd);
                        Console.WriteLine();
                        figure.Draw();
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("Enter X");
                        int xRng = Tools.Validate(true);
                        Console.WriteLine("Enter Y");
                        int yRng = Tools.Validate(true);
                        Console.WriteLine("Enter radius");
                        int rInRng = Tools.Validate(false);
                        Console.WriteLine("Enter second radius");
                        int rOutRng = Tools.Validate(false);
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
                        int xRec = Tools.Validate(true);
                        Console.WriteLine("Enter Y");
                        int yRec = Tools.Validate(true);
                        Console.WriteLine("Enter hight");
                        int height = Tools.Validate(false);
                        Console.WriteLine("Enter width");
                        int width = Tools.Validate(false);
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
    }
}
