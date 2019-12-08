using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    internal class DynamicArray<T> : IEnumerable<T>, ICloneable
    {
        private int _capasity;
        public int Length { get; private set; }
        protected T[] InnerArray { get; private set; }
        public DynamicArray()
        {
            _capasity = 8;
            Length = 0;
            InnerArray = new T[_capasity];
        }
        public DynamicArray(int capasity)
        {
            _capasity = capasity;
            Length = 0;
            InnerArray = new T[capasity];
        }
        public DynamicArray(IEnumerable<T> col)
        {
            _capasity = col.Count() * 2;
            Length = 0;
            InnerArray = new T[_capasity];
            foreach (var item in col)
            {
                Add(item);
            }
        }
        public T this[int index]
        {
            get
            {
                if (index < Length)
                {
                    if (index < 0)
                    {
                        int newIndex = index % Length;
                        return InnerArray[Length + newIndex];
                    }
                    return InnerArray[index];
                }
                throw new ArgumentOutOfRangeException(nameof(index), "Index can't be more than Length");
            }
            set
            {
                if (index < Length)
                {
                    if (index < 0)
                    {
                        int newIndex = index % Length;
                        InnerArray[Length + newIndex] = value;
                    }
                    else
                    {
                        InnerArray[index] = value;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index can't be more than Length");
                }
            }
        }
        public int Capasity
        {
            get => _capasity;
            set
            {
                _capasity = value;
                if (_capasity < Length)
                {
                    T[] tempArr = new T[InnerArray.Length];
                    for (int i = 0; i < InnerArray.Length; i++)
                    {
                        tempArr[i] = InnerArray[i];
                    }
                    InnerArray = new T[_capasity];
                    Length = 0;
                    for (int i = 0; i < _capasity; i++)
                    {
                        Add(tempArr[i]);
                    }
                }
            }
        }
        public void Add(T ell)
        {
            if (Length < _capasity)
            {
                InnerArray[Length] = ell;
                Length++;
            }
            else
            {
                _capasity *= 2;
                T[] tempArr = new T[InnerArray.Length];
                for (int i = 0; i < InnerArray.Length; i++)
                {
                    tempArr[i] = InnerArray[i];
                }
                InnerArray = new T[_capasity];
                for (int i = 0; i < tempArr.Length; i++)
                {
                    InnerArray[i] = tempArr[i];
                }
                InnerArray[Length] = ell;
                Length++;
            }
        }
        public bool Remove(int index)
        {
            int temp = Length;
            bool result = true;
            for (int i = index; i < Length - 1; i++)
            {
                InnerArray[i] = InnerArray[i + 1];
            }
            InnerArray[Length] = default(T);
            Length--;
            if (Length == temp)
            {
                result = false;
            }
            return result;
        }
        public bool Insert(int index, T ell)
        {
            bool result = true;
            int temp = Length;
            if (Length == _capasity)
            {
                _capasity *= 2;
            }
            Length++;
            for (int i = Length - 1; i > index; i--)
            {
                InnerArray[i] = InnerArray[i - 1];
            }
            InnerArray[index] = ell;
            if (Length == temp)
            {
                result = false;
            }
            return result;
        }
        public void AddRange(IEnumerable<T> col)
        {
            var cnt = col.Count();
            if ((Length + cnt) >= _capasity)
            {
                _capasity = (InnerArray.Count() + cnt) * 2;
                T[] tempArr = new T[InnerArray.Length];
                for (int i = 0; i < InnerArray.Length; i++)
                {
                    tempArr[i] = InnerArray[i];
                }
                InnerArray = new T[_capasity];
                for (int i = 0; i < tempArr.Length; i++)
                {
                    InnerArray[i] = tempArr[i];
                }
            }
            foreach (var item in col)
            {
                Add(item);
            }
        }
        public T[] ToArray()
        {
            T[] arr = new T[Length];
            for (int i = 0; i < Length; i++)
            {
                arr[i] = InnerArray[i];
            }
            return arr;
        }
        public object Clone()
        {
            DynamicArray<T> newArr = new DynamicArray<T>(_capasity);
            for (int i = 0; i < Length; i++)
            {
                newArr.Add(InnerArray[i]);
            }
            return newArr;
        }
        public virtual IEnumerator<T> GetEnumerator()
        {
            return new DynamicArrayEnum<T>(InnerArray, Length);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
