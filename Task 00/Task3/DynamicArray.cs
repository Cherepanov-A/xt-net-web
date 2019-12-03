using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    internal class DynamicArray<T> : IEnumerable<T>, ICloneable
    {
        private int _capasity;
        private T[] _innerArray;
        public int Length { get; private set; }

        public DynamicArray()
        {
            _capasity = 8;
            Length = 0;
            _innerArray = new T[_capasity];
        }

        public DynamicArray(int capasity)
        {
            _capasity = capasity;
            Length = 0;
            _innerArray = new T[capasity];
        }

        public DynamicArray(IEnumerable<T> col)
        {
            _capasity = col.Count() * 2;
            Length = 0;
            _innerArray = new T[_capasity];
            foreach (var item in col)
            {
                Add(item);
            }
        }

        public virtual T this[int index]
        {
            get
            {
                if (index < Length && index >= 0)
                {
                    return _innerArray[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                if (index < Length && index >= 0)
                {
                    _innerArray[index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
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
                    T[] tempArr = new T[_innerArray.Length];
                    for (int i = 0; i < _innerArray.Length; i++)
                    {
                        tempArr[i] = _innerArray[i];
                    }
                    _innerArray = new T[_capasity];
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
                _innerArray[Length] = ell;
                Length++;
            }
            else
            {
                _capasity *= 2;
                T[] tempArr = new T[_innerArray.Length];
                for (int i = 0; i < _innerArray.Length; i++)
                {
                    tempArr[i] = _innerArray[i];
                }
                _innerArray = new T[_capasity];
                for (int i = 0; i < tempArr.Length; i++)
                {
                    _innerArray[i] = tempArr[i];
                }
                _innerArray[Length] = ell;
                Length++;
            }
        }
        public bool Remove(int index)
        {
            int temp = Length;
            bool result = true;
            for (int i = index; i < Length - 1; i++)
            {
                _innerArray[i] = _innerArray[i + 1];
            }
            _innerArray[Length] = default(T);
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
                _innerArray[i] = _innerArray[i - 1];
            }
            _innerArray[index] = ell;
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
                _capasity = (_innerArray.Count() + cnt) * 2;
                T[] tempArr = new T[_innerArray.Length];
                for (int i = 0; i < _innerArray.Length; i++)
                {
                    tempArr[i] = _innerArray[i];
                }
                _innerArray = new T[_capasity];
                for (int i = 0; i < tempArr.Length; i++)
                {
                    _innerArray[i] = tempArr[i];
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
                arr[i] = _innerArray[i];
            }
            return arr;
        }
        public object Clone()
        {
            DynamicArray<T> newArr = new DynamicArray<T>(_capasity);
            for (int i = 0; i < Length; i++)
            {
                newArr.Add(_innerArray[i]);
            }
            return newArr;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new DynamicArrayEnum<T>(_innerArray, Length);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
