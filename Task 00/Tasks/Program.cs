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
                        string temp1 = Console.ReadLine();
                        if (temp1 == "")
                        {
                            Console.WriteLine("Value can't be whitespace");
                            break;
                        }
                        double seqLen;
                        try
                        {
                            seqLen = Convert.ToInt32(temp1, CultureInfo.InvariantCulture);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Incorrect value");
                            break;
                        }
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
                        string temp2 = Console.ReadLine();
                        if (temp2 == "")
                        {
                            Console.WriteLine("Value can't be whitespace");
                            break;
                        }
                        double number;
                        try
                        {
                            number = Convert.ToDouble(temp2, CultureInfo.InvariantCulture);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Incorrect value");
                            break;
                        }
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
                        string temp3 = Console.ReadLine();
                        if (temp3 == "")
                        {
                            Console.WriteLine("Value can't be whitespace");
                            break;
                        }
                        double squareSide;
                        try
                        {
                            squareSide = Convert.ToDouble(temp3, CultureInfo.InvariantCulture);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Incorrect value");
                            break;
                        }
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
                        string temp4 = Console.ReadLine();
                        if (temp4 == "")
                        {
                            Console.WriteLine("Value can't be whitespace");
                            break;
                        }
                        double numOfDim;
                        try
                        {
                            numOfDim = Convert.ToDouble(temp4, CultureInfo.InvariantCulture);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Incorrect value");
                            break;
                        }
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
                            Console.WriteLine();
                            Console.WriteLine($"Enter size of {i + 1} dimention");

                            string temp5 = Console.ReadLine();
                            if (temp5 == "")
                            {
                                Console.WriteLine("Value can't be whitespace");
                                break;
                            }
                            double temp = Convert.ToDouble(temp5, CultureInfo.InvariantCulture);
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
