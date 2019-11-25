using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_2_4
{
    class MyString
    {
        private char[] inner;

        public MyString(string s)
        {
            inner = s.ToCharArray();
        }

        public MyString()
        {

        }

        public char this[int index]
        {
            get => inner[index];
            set => inner[index] = value;
        }

        public void Add(string s)
        {
            if (inner == null)
            {
                inner = new char[s.Length];
                s.ToCharArray().CopyTo(inner, 0);
            }
            else
            {
                char[] temp = inner;
                inner = new char[s.Length + temp.Length];
                temp.CopyTo(inner, 0);
                s.ToCharArray().CopyTo(inner, temp.Length);
            }
        }
        public void Add(char c)
        {
            if (inner == null)
            {
                inner = new char[1]{c};
            }
            else
            {
                char[] temp = inner;
                inner = new char[temp.Length+1];
                temp.CopyTo(inner, 0);
                inner[inner.Length-1]=c;
            }
        }

        public static MyString operator +(MyString s1, MyString s2)
        {
            MyString temp = new MyString();
            temp.Add(s1.ToString());
            temp.Add(s2.ToString());
            return temp;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (var item in inner)
            {
                s.Append(item);
            }
            return s.ToString();
        }

        public int Length()
        {
            return inner.Length;
        }
        public override bool Equals(object obj)
        {
            MyString str = new MyString();
            bool eql = false;
            if (obj is MyString)
            {
                str = (MyString)obj;
                if (inner.Length == str.Length())
                {
                    for (int i = 0; i < inner.Length; i++)
                    {
                        eql = inner[i] == str[i];
                    }
                }
            }
            return eql;
        }

        public static bool operator ==(MyString s1, MyString s2)
        {
            return s1.Equals(s2);
        }
        public static bool operator !=(MyString s1, MyString s2)
        {
            return !s1.Equals(s2);
        }
        public static bool operator >(MyString s1, MyString s2)
        {
            return s1.Length() > s2.Length();
        }
        public static bool operator <(MyString s1, MyString s2)
        {
            return s1.Length() < s2.Length();
        }

        public int IndexOf(char c)
        {
            int tmp = -1;
            for (int i = 0; i < inner.Length; i++)
            {
                if (inner[i] == c)
                {
                    tmp = i;
                    break;
                }
            }
            return tmp;
        }

        public MyString Substring(int start, int end)
        {
            MyString tmp = new MyString();
            for (int i = start; i < end; i++)
            {
                tmp.Add(inner[i]);
            }
            return tmp;
        }
    }
}
