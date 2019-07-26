using System;
using System.Collections.Generic;
using System.Text;

namespace _4._1._CUSTOM_SORT
{
    class MySort<T>
    {
        public void Sort(T[] arr, Func<T, T, double> simile)
        {
            if (simile == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (simile(arr[j], arr[i]) > 0)
                    {
                        var move = arr[j];
                        arr[j] = arr[i];
                        arr[i] = move;
                    }
                }
            }
        }
    }
}
