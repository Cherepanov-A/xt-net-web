using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class CycledDynamicArray<T> : DynamicArray<T>
    {
        public CycledDynamicArray(int capasity) : base(capasity)
        {

        }
        public CycledDynamicArray(IEnumerable<T> col) : base(col)
        {

        }
        public CycledDynamicArray() { }

        public override IEnumerator<T> GetEnumerator()
        {
            return new CycledDynamicArrayEnum<T>(InnerArray, Length);
        }
    }
}
