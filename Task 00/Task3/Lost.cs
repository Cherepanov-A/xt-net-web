using System;
using System.Collections.Generic;

namespace Task3
{
    internal class Lost
    {
        internal static void LastManStanding(int n)
        {
            List<int> arr = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                arr.Add(i);
            }
            Print(arr);
            int p = 1;
            while (arr.Count > 1)
            {
                for (int i = p; i < arr.Count; i++)
                {
                    arr.Remove(arr[i]);
                    if (i == arr.Count - 2)
                    {
                        p = 1;
                    }
                    if (i == arr.Count - 1)
                    {
                        p = 0;
                    }
                }
               Print(arr);
            }
            Console.ReadKey();
        }
        private static void Print(List<int> arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
