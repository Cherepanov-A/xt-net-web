using System;
using System.Collections.Generic;

namespace Task3
{
    internal class DynamicArrayEnum<T> : IEnumerator<T>
    {
        private readonly T[] _innerArray;
        private readonly int _length;
        private int _position = -1;
        protected T[] InnerArray => _innerArray;
        protected int Length => _length;

        protected int Position
        {
            get => _position;
            set => _position = value;
        }

        public DynamicArrayEnum(T[] da, int length)
        {
            _innerArray = new T[length];
            _length = length;
            for (int i = 0; i < length; i++)
            {
                _innerArray[i] = da[i];
            }
        }

        public  object Current
        {
            get
            {
                if (_position < 0 || _position >= _length)
                    throw new InvalidOperationException();
                return _innerArray[_position];
            }
        }
         T IEnumerator<T>.Current
        {
            get
            {
                if (_position < 0 || _position >= _length)
                    throw new InvalidOperationException();
                return _innerArray[_position];
            }
        }
        public void Dispose()
        {
        }
        public virtual bool MoveNext()
        {
            if (_position < _length - 1)
            {
                _position++;
                return true;
            }
            return false;
        }
        public void Reset()
        {
            _position = -1;
        }
    }
}
