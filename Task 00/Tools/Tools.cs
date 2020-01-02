using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Other
{
    public class Tools
    {
        public static int Validate(bool negative)
        {
            bool check = true;
            int val = 0;
            while (check)
            {
                if (negative)
                {
                    if (int.TryParse(Console.ReadLine(), out val))
                    {
                        check = false;
                    }
                    else
                    {
                        Console.WriteLine("Enter integer value");
                    }
                }
                else
                {
                    if (int.TryParse(Console.ReadLine(), out val) && val > 0)
                    {
                        check = false;
                    }
                    else
                    {
                        Console.WriteLine("Enter positive, integer value");
                    }
                }
            }
            return val;
        }
    }
}
