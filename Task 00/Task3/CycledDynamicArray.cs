using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class CycledDynamicArray<T> : DynamicArray<T>
    {
        public CycledDynamicArray(int capasity):base (capasity)
        {
                
        }
        public CycledDynamicArray(IEnumerable<T> col):base(col)
        {
            
        }
        public override T this[int index]
        {
            get
            {
                if (index < Length)
                {
                    if (index < 0)
                    {
                        int newIndex = index % Length;
                        return base [Length + newIndex];
                    }
                    else
                    {
                        return base[index];
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                if (index < Length)
                {
                    if (index < 0)
                    {
                        int newIndex = index % Length;
                        base[Length + newIndex] = value;
                    }
                    else
                    {
                        base[index] = value;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
