using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class WordFrequency
    {
        internal static void FCount(string s)
        {
            string[] source;
            if (s!=null)
            {
                char[] splt = {' ', '.'};
                source = s.Split(splt, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                throw new NullReferenceException("Input parameter is empty");
            }
            Dictionary<string, int> result = new Dictionary<string,int>();
            for (int i = 0; i < source.Length; i++)
            {
                if (result.ContainsKey(source[i]))
                {
                    result[source[i]]++;
                }
                else
                {
                    result.Add(source[i], 1);
                }
            }
            double percent=source.Length*0.01;
            foreach (var i in result)
            {
                var freq = i.Value / percent;
                Console.WriteLine($"Frequency of {i.Key} is {freq:##.###} percents.");
            }
        }
    }
}
