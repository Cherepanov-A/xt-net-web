using System;
using System.Linq;

namespace Task4
{
    internal static class IntArrExtention
    {
        internal static double ArraySum<T>(this T[] arr) where T : struct
        {
            double sum = 0;
            var isNumber = false;
            if (arr != null && arr.Length > 0)
            {
                var type = arr[0].GetType();
                isNumber = (type.IsPrimitive && type != typeof(bool) && type != typeof(char));
            }
            if (!isNumber) return sum;
            try
            {
                return arr.Sum(t => Convert.ToDouble(t));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }
    }
}
