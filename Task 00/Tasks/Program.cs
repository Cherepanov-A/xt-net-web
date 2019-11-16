using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = true;
            while (quit)
            {
                Console.WriteLine();
                Console.WriteLine("Choose what you want to do:");
                Console.WriteLine("1. Sequence");
                Console.WriteLine("2. Simple");
                Console.WriteLine("3. Square");
                Console.WriteLine("4. Array");
                Console.WriteLine("or");
                Console.WriteLine("Press q to quit");
                Console.WriteLine();
                ConsoleKeyInfo btn = Console.ReadKey();
                Console.WriteLine();
                switch (btn.KeyChar)
                {
                    case '1':
                        Console.WriteLine();
                        Console.WriteLine("Enter the positive and integer length of Sequence");
                        Console.WriteLine();
                        string temp = Console.ReadLine(); 
                        double seqLen =


                        if (seqLen <= 0)
                        {
                            Console.WriteLine("Not positive value");
                            break;
                        }
                        if (seqLen % 1 != 0)
                        {
                            Console.WriteLine("Not integer value");
                            break;
                        }
                        Console.WriteLine();
                        Sequince(seqLen);
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    case '2':
                        Console.WriteLine();
                        Console.WriteLine("Enter the positive and integer length of Sequence");
                        Console.WriteLine();
                        double number = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                        if (number <= 0)
                        {
                            Console.WriteLine("Not positive value");
                            break;
                        }
                        if (number % 1 != 0)
                        {
                            Console.WriteLine("Not integer value");
                            break;
                        }
                        Console.WriteLine();
                        Simple(number);
                        break;
                    case '3':
                        Console.WriteLine();
                        Console.WriteLine("Enter the positive, integer and odd length of Sequence");
                        Console.WriteLine();
                        double squareSide = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                        if (squareSide <= 0)
                        {
                            Console.WriteLine("Not positive value");
                            break;
                        }
                        if (squareSide % 1 != 0)
                        {
                            Console.WriteLine("Not integer value");
                            break;
                        }
                        if (squareSide % 2 == 0)
                        {
                            Console.WriteLine("Even value");
                            break;
                        }
                        Console.WriteLine();
                        Square(squareSide);
                        break;
                    case '4':
                        Console.WriteLine();
                        Console.WriteLine("Enter the positive and integer number of dimentions");
                        double numOfDim = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                        if (numOfDim <= 0)
                        {
                            Console.WriteLine("Not positive value");
                            break;
                        }
                        if (numOfDim % 1 != 0)
                        {
                            Console.WriteLine("Not integer value");
                            break;
                        }
                        int[] sizesOfDim = new int[(int)numOfDim];
                        for (int i = 0; i < numOfDim; i++)
                        {
                            Console.WriteLine($"Enter size of {i + 1} dimention");
                            double temp = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                            if (numOfDim <= 0)
                            {
                                Console.WriteLine("Not positive value");
                                break;
                            }
                            if (numOfDim % 1 != 0)
                            {
                                Console.WriteLine("Not integer value");
                                break;
                            }
                            sizesOfDim[i] = (int)temp;
                        }
                        Random rnd = new Random();
                        int[][] arr = new int[(int)numOfDim][];
                        for (int i = 0; i < arr.Length; i++)
                        {
                            arr[i] = new int[sizesOfDim[i]];
                            for (int j = 0; j < arr[i].Length; j++)
                            {
                                arr[i][j] = rnd.Next(100);
                            }
                        }
                        for (int i = 0; i < arr.Length; i++)
                        {
                            // Console.Write("{");
                            for (int j = 0; j < arr[i].Length; j++)
                            {
                                Console.Write("{" + arr[i][j] + "},");
                            }
                            Console.WriteLine();
                        }

                        Console.WriteLine();

                        Array.ConvertAll(arr, Converter<int[][], int[]>);
                        for (int i = 0; i < arr.Length; i++)
                        {
                            // Console.Write("{");
                            for (int j = 0; j < arr[i].Length; j++)
                            {
                                Console.Write("{" + arr[i][j] + "},");
                            }
                            Console.WriteLine();
                        }

                        //MyArray();
                        break;
                    case 'q':
                        quit = false;
                        break;

                }
            }
        }

        private static void MyArray()
        {
            int[,,,,] a = new int[2, 2, 2, 2, 2];
            Console.WriteLine(a.ToString());
            Console.WriteLine();
        }

        private static void Square(double squareSide)
        {
            int half = (int)squareSide / 2;
            for (int i = 1; i <= half; i++)
            {
                Console.WriteLine(new string('*', (int)squareSide));
            }
            Console.Write(new string('*', half));
            Console.Write(" ");
            Console.WriteLine(new string('*', half));
            for (int i = 1; i <= half; i++)
            {
                Console.WriteLine(new string('*', (int)squareSide));
            }
        }

        private static void Simple(double number)
        {
            if (number % 2 == 0)
            {
                Console.WriteLine($"{number} is not prime");
                return;
            }
            double limit = Math.Sqrt(number);
            bool isPrime = true;
            for (int i = 2; i <= limit; i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                }
            }
            if (isPrime)
            {
                Console.WriteLine($"{number} is prime");
            }
            else
            {
                Console.WriteLine($"{number} is not prime");
            }
        }

        private static void Sequince(double seqLen)
        {

            Console.Write("1");
            for (int i = 2; i <= seqLen; i++)
            {
                Console.Write("," + i);
            }

        }
    }
}
