using System;
using System.Collections.Generic;
using System.Text;

namespace _3._4.__DYNAMIC_ARRAY__HARDCORE_MODE_
{
    class CycledDynamicArray<T> : MyDynamicArray<T>
    {
        public CycledDynamicArray():base(capacity:8)
        {
                
        }

        public CycledDynamicArray(int capacity): base(capacity)
        {

        }
        public CycledDynamicArray(IEnumerable<T> someCollection):base(someCollection)
        {

        }

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0;; i++)
            {
                if (i == Capacity)
                    i = 0;
                yield return Array[i];
            }
        }
    }
}
