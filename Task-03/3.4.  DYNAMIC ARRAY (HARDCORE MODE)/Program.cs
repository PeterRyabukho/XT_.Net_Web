using System;
using System.Collections.Generic;
using System.Collections;

namespace _3._4.__DYNAMIC_ARRAY__HARDCORE_MODE_
{
    class Program
    {
        static void Main()
        {
            Console.Write("An array of 8 elements is created:  ");
            MyDynamicArray<int> arr = new MyDynamicArray<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            ShowThisCollection(arr);

            Console.Write("1. Y can access to elements from the end of collection using a negative index (-1: last, -2, etc): ");
            bool res = int.TryParse(Console.ReadLine(), out int N);
            if (res)
                Console.Write($"\nIndex  [{N}]: {arr[N]}\n\n");
            else
            {
                Console.WriteLine("Enter integer, you can enter negative numbers!");
                Main();
            }

            Console.Write("\nArray of what size would you like to install? Choose Capacity, enter an integer greater than 0: ");
            bool res2 = int.TryParse(Console.ReadLine(), out int X);
            if(res2 && X > 0)
            {
                Console.WriteLine($"\n2. Manually change the value of Capacity, now its - {X}, while preserving the surviving data: ");
                arr.Capacity = X;
                ShowThisCollection(arr);

            }
            else
            {
                Console.WriteLine("Enter integer, you CAN't enter negative numbers!");
                Main();
            }

            Console.WriteLine("3. Implement the ICloneable interface to create a copy of the array.\n");
            ICloneable<int> arrClone = arr;
            Console.Write("Original array:  ");
            ShowThisCollection(arr);
            Console.Write("ICloneable array:  ");
            ShowThisCollection(arrClone.Clone());

            Console.WriteLine("4. 'ToArray method', which returns a new (regular) array containing all the objects contained in the current dynamic array: ");
            ShowThisCollection(arr.ToArray());

            Console.WriteLine("5. CycledDynamicArray - when using foreach after the last element, the first must go again and so on in a circle: ");
            Console.Write("\nY want to run an endless loop now? Click button Y/N: ");
            ConsoleKeyInfo btn = Console.ReadKey();
            if (btn.Key == ConsoleKey.Y)
            {
                CycledDynamicArray<int> cycledArr = new CycledDynamicArray<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
                ShowThisCollection(cycledArr);
            }

            Console.ReadKey();
        }

        private static void ShowThisCollection<T>(IEnumerable<T> arr)
        {
            Console.Write("[");
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("]\n\n");

        }
    }
}
