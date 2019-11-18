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
                        bool check1 = true;
                        Console.WriteLine();
                        Console.WriteLine("Enter the positive and integer length of Sequence");
                        Console.WriteLine();
                        int seqLen = 0;
                        do
                        {
                            if (int.TryParse(Console.ReadLine(), out seqLen))
                            {
                                Console.WriteLine();
                                check1 = false;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Enter correct integer value");
                            }
                            if (seqLen <= 0 && check1 == false)
                            {
                                Console.WriteLine("Not positive value");
                                check1 = true;
                            }
                            
                        } while (check1);
                        Console.WriteLine();
                        Sequince(seqLen);
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                    case '2':
                        bool check2 = true;
                        Console.WriteLine();
                        Console.WriteLine("Enter the positive and integer length of Sequence");
                        Console.WriteLine();
                        
                        int number=0;
                        do
                        {
                            if (int.TryParse(Console.ReadLine(), out number))
                            {
                                Console.WriteLine();
                                check1 = false;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Enter correct integer value");
                            }
                            if (number <= 0 && check2 == false)
                            {
                                Console.WriteLine("Not positive value");
                                check2 = true;
                            }
                           
                        } while (check2);
                        Console.WriteLine();
                        Simple(number);

                        break;

                    case '3':
                        bool check3 = true;
                        int squareSide = 0;
                        Console.WriteLine();
                        Console.WriteLine("Enter the positive, integer and odd length of Sequence");
                        do
                        {
                            Console.WriteLine();
                            if (int.TryParse(Console.ReadLine(), out squareSide))
                            {
                                Console.WriteLine();
                                check3 = false;

                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Enter correct value");

                            }
                            if (squareSide <= 0 && check3 == false)
                            {
                                Console.WriteLine("Enter positive value");
                                check3 = true;

                            }
                            if (squareSide % 2 == 0 && check3 == false)
                            {
                                Console.WriteLine("Enter odd value");
                                check3 = true;
                            }
                        } while (check3);
                        Console.WriteLine();
                        Square(squareSide);
                        break;

                    case '4':
                        Console.WriteLine();
                        Console.WriteLine("Enter the positive and integer number of dimentions");
                        bool check4 = true;
                        int numOfDim=0;
                        do
                        {
                            if (int.TryParse(Console.ReadLine(), out numOfDim))
                            {
                                Console.WriteLine();
                                check4 = false;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Enter correct integer value");
                            }
                            if (numOfDim <= 0 && check4 == false)
                            {
                                Console.WriteLine("Not positive value");
                                check4 = true;
                            }
                        } while (check4);

                        int[] sizesOfDim = new int[numOfDim];

                        for (int i = 0; i < numOfDim; i++)
                        {
                            bool check5 = true;
                            Console.WriteLine();
                            Console.WriteLine($"Enter size of {i + 1} dimention");
                            int dimSize = 0;
                            do
                            {
                                if (int.TryParse(Console.ReadLine(), out dimSize))
                                {
                                    Console.WriteLine();
                                    check5 = false;
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Enter correct integer value");
                                }
                                if (dimSize <= 0 && check5 == false)
                                {
                                    Console.WriteLine("Not positive value");
                                    check5 = true;
                                }
                            } while (check5);
                            sizesOfDim[i] = dimSize;
                        }
                        Console.WriteLine();
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
                            for (int j = 0; j < arr[i].Length; j++)
                            {
                                Console.Write("{" + arr[i][j] + "},");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        MyArraySort(arr);
                        for (int i = 0; i < arr.Length; i++)
                        {
                            for (int j = 0; j < arr[i].Length; j++)
                            {
                                Console.Write("{" + arr[i][j] + "},");
                            }
                            Console.WriteLine();
                        }
                        break;

                    case 'q':
                        quit = false;
                        break;
                }
            }
        }

        private static void MyArraySort(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int[] tmp = arr[i];
                Array.Sort(tmp);
                arr[i] = tmp;
            }
            bool sorted = true;
            while (sorted)
            {
                sorted = false;
                for (int i = 1; i < arr.Length; i++)
                {

                    if (arr[i].Length < arr[i - 1].Length)
                    {
                        int[] tmp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = tmp;
                        sorted = true;
                    }
                    if (arr[i].Length == arr[i - 1].Length && arr[i][0] < arr[i - 1][0])
                    {
                        int[] tmp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = tmp;
                        sorted = true;
                    }
                }
            }
        }

        private static void Square(int squareSide)
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

        private static void Simple(int number)
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

        private static void Sequince(int seqLen)
        {

            Console.Write("1");
            for (int i = 2; i <= seqLen; i++)
            {
                Console.Write("," + i);
            }

        }
    }
}
