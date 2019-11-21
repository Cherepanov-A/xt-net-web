using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_11_1_12
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;

    namespace Task1_11_1_12
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter text");
                string source = Console.ReadLine();
                AvarageWord(source);
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Entre first string");
                string a = Console.ReadLine();
                Console.WriteLine("Entre second string");
                string b = Console.ReadLine();
                CharDoubler(a, b);

                Console.ReadLine();
            }

            private static void CharDoubler(string a, string b)
            {
                bool contains;
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < a.Length; i++)
                {
                    contains = false;
                    builder.Append(a[i]);
                    for (int j = 0; j < b.Length; j++)
                    {
                        if (a[i] == b[j])
                        {
                            contains = true;
                        }
                    }
                    if (contains)
                    {
                        builder.Append(a[i]);
                    }
                }
                Console.WriteLine(builder);
            }

            private static void AvarageWord(string source)
            {
                string[] stArr = source.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                List<StringBuilder> builders = new List<StringBuilder>();
                for (int i = 0; i < stArr.Length; i++)
                {
                    builders.Add(new StringBuilder());
                    for (int j = 0; j < stArr[i].Length; j++)
                    {
                        if ((char.IsLetter(stArr[i][j]) || char.IsDigit(stArr[i][j]) || char.IsNumber(stArr[i][j])))
                        {
                            builders[i].Append(stArr[i][j]);
                        }
                    }
                }
                int sum = 0;
                int count = 0;
                foreach (var s in builders)
                {
                    if (s.Length > 0)
                    {
                        sum += s.Length;
                        count++;
                    }
                }
                if (count > 0)
                {
                    int average = sum / count;
                    Console.WriteLine(average);
                }
                else
                {
                    Console.WriteLine("There are no words in text");
                }
            }
        }
    }
}
