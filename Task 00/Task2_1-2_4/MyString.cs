using System.Text;

namespace Task2_1_2_4
{
    internal class MyString
    {
        private char[] _inner;
        public MyString(string s)
        {
            _inner = s.ToCharArray();
        }
        public MyString()
        {

        }
        public char this[int index]
        {
            get => _inner[index];
            set => _inner[index] = value;
        }
        public void Add(string s)
        {
            if (_inner == null)
            {
                _inner = new char[s.Length];
                s.ToCharArray().CopyTo(_inner, 0);
            }
            else
            {
                char[] temp = _inner;
                _inner = new char[s.Length + temp.Length];
                temp.CopyTo(_inner, 0);
                s.ToCharArray().CopyTo(_inner, temp.Length);
            }
        }
        public void Add(char c)
        {
            if (_inner == null)
            {
                _inner = new char[1] { c };
            }
            else
            {
                char[] temp = _inner;
                _inner = new char[temp.Length + 1];
                temp.CopyTo(_inner, 0);
                _inner[_inner.Length - 1] = c;
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
            foreach (var item in _inner)
            {
                s.Append(item);
            }
            return s.ToString();
        }
        public int Length()
        {
            return _inner.Length;
        }
        public override bool Equals(object obj)
        {
            bool eql = false;
            if (obj is MyString)
            {
                var str = (MyString)obj;
                if (_inner.Length == str.Length())
                {
                    for (int i = 0; i < _inner.Length; i++)
                    {
                        eql = _inner[i] == str[i];
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
            for (int i = 0; i < _inner.Length; i++)
            {
                if (_inner[i] == c)
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
                tmp.Add(_inner[i]);
            }
            return tmp;
        }

        public override int GetHashCode()
        {
            return _inner.ToString().GetHashCode();
        }
    }
}
