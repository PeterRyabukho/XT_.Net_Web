using System;
using System.Collections.Generic;
using System.Collections;

namespace _3._4.__DYNAMIC_ARRAY__HARDCORE_MODE_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("An array of 8 elements is created:  ");
            MyDynamicArray<int> arr = new MyDynamicArray<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            ShowThisCollection(arr);

            Console.Write("1. Y can access to elements from the end of collection using a negative index (-1: last, -2, etc): ");
            bool res = int.TryParse(Console.ReadLine(), out int N);
            if(res)
                Console.Write($"Index  [{N}]: {arr[N]}\n\n");
            else Console.WriteLine("Enter integer, you can enter negative numbers!");

            arr.Capacity = 5;
            ShowThisCollection(arr);

            Console.WriteLine("4. 'ToArray method', which returns a new (regular) array containing all the objects contained in the current dynamic array: ");
            arr.ToArray();
            ShowThisCollection(arr);

            ICloneable<int> arrClone = arr;
            ShowThisCollection(arr);
            ShowThisCollection(arrClone.Clone());
        }

        private static void ShowThisCollection<T>(IEnumerable<T> arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n\n");
        }
    }
}
