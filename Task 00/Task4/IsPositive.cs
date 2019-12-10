using System;
using System.Linq;

namespace Task4
{
    internal static class IsPositive
    {
        public static bool IsPositiveNumber(this string s)
        {
            string s1 = "";
            if (s.Length==0)
            {
                return false;
            }
            string[] temp = s.Split('.');
            if (temp.Length > 1)
            {
                return false;
            }
            temp = s.Split('E','e');
            if (temp.Length == 2)
            {
                s1 = temp[0];
                string s2 = temp[1];
                if (s1.Length > 1)
                {
                    throw new ArgumentException("Number before E can't be higher than 9");
                }
                if (s2[0] == '-')
                {
                    return false;
                }
            }
            if(temp.Length==1)
            {
                s1 = temp[0];
            }
            if (s1[0] == '-')
            {
                return false;
            }
            if (s1[0] == '+' && s1.Length < 2)
            {
                return false;
            }
            if (s1[0] != '+' && !char.IsDigit(s1[0]))
            {
                return false;
            }
            if (!(s1.Substring(1, s1.Length - 1).All((char.IsDigit))))
            {
                return false;
            }
            return true;
        }
    }
}

