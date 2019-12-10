using System;
using System.Threading;

namespace Task4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TreadTwoRun();
            ThreadOneRun();
        }

        private static void ThreadOneRun()
        {
            Console.WriteLine("Thread 1 starts");
            int[] arr = CustomSortDemo();
            Console.WriteLine($"Sum of items in arr = {arr.ArraySum()}");
            Console.WriteLine();
            IsPositiveDemo();
            ICQ.Run();
            Thread.Sleep(50);
            Console.WriteLine("Thread 1 is done");
            Console.WriteLine("Press any key to close thread 1");
            Console.ReadKey();
            Console.WriteLine("Thread 1 was closed");
        }

        private static int[] CustomSortDemo()
        {
            int[] arr = { 6, 5, 47, 8, 2, 4, 6, 2, 58, 5 };
            string[] s = { "asd", "hsdfgf", "asg", "ueot", "hello", "asd" };
            Sort<int> intSort = CustomSort.CustomEqual;
            var sortedInt = CustomSort.Sort(arr, intSort);
            Console.WriteLine("Int sorting in thread 1:" + Environment.NewLine);
            SortingThreat.Print(sortedInt);            
            Sort<string> strSort = CustomSort.CustomEqual;
            var sortedStr = CustomSort.Sort(s, strSort);
            Console.WriteLine("String sorting in thread 1:" + Environment.NewLine);
            SortingThreat.Print(sortedStr);            
            return arr;
        }

        private static void TreadTwoRun()
        {
            var srtThr = new SortingThreat();
            srtThr.Done += ShowMessage;
            var myThread = new Thread(srtThr.SortStart);
            myThread.Start();
        }

        private static void IsPositiveDemo()
        {
            Console.WriteLine("Is positive:");
            const string str1 = "124";
            const string str2 = "-124";
            const string str3 = "1e24";
            Console.WriteLine($"{str1} - {str1.IsPositiveNumber()}");
            Console.WriteLine($"{str2} - {str2.IsPositiveNumber()}");
            Console.WriteLine($"{str3} - {str3.IsPositiveNumber()}");
            Console.WriteLine();
        }

        private static void ShowMessage(object sender, Thr2EventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
