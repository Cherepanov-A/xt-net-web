using System;
using System.Collections.Generic;

namespace Task3
{
    internal class DynamicArrayEnum<T> : IEnumerator<T>
    {
        private readonly T[] _innerArray;
        private readonly int _length;
        private int _position;
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
            Position=-1;
            for (int i = 0; i < length; i++)
            {
                _innerArray[i] = da[i];
            }
        }

        public  object Current
        {
            get
            {
                if (Position < 0 || Position >= _length)
                    throw new ArgumentOutOfRangeException(nameof(Position));
                return _innerArray[Position];
            }
        }

         T IEnumerator<T>.Current
        {
            get
            {
                if (Position < 0 || Position >= _length)
                    throw new ArgumentOutOfRangeException(nameof(Position));
                return _innerArray[Position];
            }
        }

        public void Dispose()
        {
        }

        public virtual bool MoveNext()
        {
            if (Position < _length - 1)
            {
                Position++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            Position = -1;
        }
    }
}
