using System;
using System.Collections.Generic;
using System.Text;

namespace _4._3._SORTING_UNIT
{
    class MyArraySorting
    {
        public event Action<string> OnComplite;

        public void SortMyArr<T>(T[] arr, Func<T, T, bool> comp)
        {
            if (comp == null)
            {
                throw new ArgumentNullException("Array is empty!");
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (comp(arr[i], arr[j]))
                    {
                        var move = arr[i];
                        arr[i] = arr[j];
                        arr[j] = move;

                    }
                }
            }
            OnComplite.Invoke("Done!");
        }

        public void ShowMeThisArray<T>(T[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
