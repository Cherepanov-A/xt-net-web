using System;
using System.Collections.Generic;

namespace Task3
{
    internal class CycledDynamicArrayEnum<T> : DynamicArrayEnum<T>, IEnumerator<T>
    {
        public CycledDynamicArrayEnum(T[] da, int length) : base(da, length)
        {

        }
        T IEnumerator<T>.Current
        {
            get
            {
                if (Position >= Length)
                    Position = 0;
                if (Position < -1)
                {
                    throw new ArgumentOutOfRangeException(nameof(Position));
                }
                return InnerArray[Position];
            }
        }
        public override bool MoveNext()
        {
            if (Position < Length - 1)
            {
                Position++;
                return true;
            }
            Position = 0;
            return true;
        }
    }
}
