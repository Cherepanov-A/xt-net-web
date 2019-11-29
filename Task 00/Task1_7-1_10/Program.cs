using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_7_1_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ARRAY PROCESSING", Console.ForegroundColor=ConsoleColor.Magenta);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            ArrayProcessing();
            Console.WriteLine();
            Console.Write("NO POSITIVE", Console.ForegroundColor = ConsoleColor.Magenta);
            Console.ForegroundColor = ConsoleColor.Gray;            
            NoPositive();
            Console.WriteLine();
            Console.WriteLine("NON-NEGATIVE SUM", Console.ForegroundColor = ConsoleColor.Magenta);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            NonNegativeSum();
            Console.WriteLine();
            Console.WriteLine("2D ARRAY", Console.ForegroundColor = ConsoleColor.Magenta);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            TwoDimArr();
            Console.ReadLine();
        }

        private static void TwoDimArr()
        {
            Random rnd = new Random();
            int[,] arr = new int[9, 6];
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rnd.Next(20);
                    if ((i + j) % 2 == 0)
                    {
                        sum += arr[i, j];
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write($"{arr[i, j]} ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Sum = {sum}");
        }

        private static void NonNegativeSum()
        {
            int sum = 0;
            Random rnd = new Random();
            int[] arr = new int[50];
            for (int i = 0; i < 50; i++)
            {
                arr[i] = rnd.Next(100) - rnd.Next(50);
                Console.Write($"{arr[i]} ");
                if (arr[i] > 0)
                {
                    sum += arr[i];
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Sum = {sum}");
        }

        private static void NoPositive()
        {
            int[,,] arr = new int[3, 4, 3];
            Random rnd = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine();
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        arr[i, j, k] = (rnd.Next(100) - rnd.Next(50));
                        Console.Write($"{arr[i, j, k]} ");
                        if (arr[i, j, k] > 0)
                        {
                            arr[i, j, k] = 0;
                        }
                    }
                }
            }
            Console.WriteLine();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine();
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {                        
                        Console.Write($"{arr[i, j, k]} ");                        
                    }
                }
            }            
            Console.WriteLine();
        }

        private static void ArrayProcessing()
        {
            Random rnd = new Random();
            int[] arr = new int[50];
            for (int i = 0; i < 50; i++)
            {
                arr[i] = rnd.Next(100);
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine();
            int left = 0;
            int right = arr.Length;
            bool done = true;
            while (done)
            {
                done = false;
                if (left < right)
                {
                    for (int i = left + 1; i < right; i++)
                    {
                        if (arr[i - 1] > arr[i])
                        {
                            int temp = arr[i - 1];
                            arr[i - 1] = arr[i];
                            arr[i] = temp;
                            done = true;
                        }
                    }
                    right--;
                    for (int i = right; i > left; i--)
                    {
                        if (arr[i - 1] > arr[i])
                        {
                            int temp = arr[i - 1];
                            arr[i - 1] = arr[i];
                            arr[i] = temp;
                            done = true;
                        }
                    }
                    left++;
                }
            }
            Console.WriteLine($"Min value = {arr[0]}");
            Console.WriteLine($"Max value = {arr.Last()}");
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
        }
    }
}
