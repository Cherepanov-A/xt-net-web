using System;
using System.Collections.Generic;


namespace Task4
{
    internal delegate int Sort<in T>(T arg1, T arg2);

    internal class CustomSort
    {
        internal static T[] Sort<T>(T[] arr, Sort<T> s)
        {
            var isOver = true;
            var left = 0;
            var right = arr.Length;
            while (isOver)
            {
                isOver = false;
                if (left >= right) continue;
                for (var i = left + 1; i < right; i++)
                {
                    if (s?.Invoke(arr[i - 1], arr[i]) != 1) continue;
                    var temp = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = temp;
                    isOver = true;
                }
                right--;
                for (var i = right; i > left; i--)
                {
                    if (s?.Invoke(arr[i - 1], arr[i]) != 1) continue;
                    var temp = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = temp;
                    isOver = true;
                }
                left++;
            }
            return arr;
        }

        internal static int CustomEqual(string a, string b)
        {
            var result = a.Length > b.Length ? 1 : a.Length < b.Length ? -1 : 0;
            if (result != 0) return result;
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] > b[i])
                {
                    result = 1;
                    break;
                }
                if (a[i] < b[i])
                {
                    result = -1;
                }
            }
            return result;
        }
        
        internal static int CustomEqual(int a, int b)
        {
            var result = a > b ? 1 : a < b ? -1 : 0;            
            return result;
        }

    }
}
