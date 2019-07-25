using System;
using System.Collections.Generic;

namespace _3._3._DYNAMIC_ARRAY
{
    class Program
    {
        static void Main()
        {
            Console.Write("1. An array of 8 elements is created:  ");
            MyDynamicArray<int> arr = new MyDynamicArray<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            ShowThisCollection(arr);

            Console.Write("2. Creates an array of the specified capacity:  ");
            var arr2 = new MyDynamicArray<int>(10) { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ShowThisCollection(arr2);

            Console.WriteLine("3. Creates an array of the desired size and copies into it all the elements from the collection:  ");
            Console.Write("Create new List of Int:  ");
            List<int> list = new List<int> { 1, 22, 74, 3, 202, 41, 33, 7843, 55, 4343, 32 };
            ShowThisCollection(list);
            Console.Write("And now copies all elements in collection:  ");
            var arr3 = new MyDynamicArray<int>(list);
            ShowThisCollection(arr3);

            Console.Write("4. 'The Add method', which adds one element to the end of the array:  ");
            arr2.Add(77);
            ShowThisCollection(arr2);

            Console.WriteLine("5. 'The AddRange method', that adds to the end of the array the contents of a collection that implements the IEnumerable <T> interface:  ");
            arr2.AddRange(arr);
            ShowThisCollection(arr2);

            Console.Write("Which item would you like to remove from the previous collection? ");
            bool res = int.TryParse(Console.ReadLine(), out int N);
            if (res)
            {
                Console.WriteLine($"\n6. 'The Remove method' that removes the specified item from the collection: {arr2.Remove(N)}");
                ShowThisCollection(arr2);
            }
            else
            {
                Console.WriteLine("Excaption! Enter Int type!\n");
                Main();
            }

            Console.Write("Enter the number you want to insert into the collection: ");
            bool res2 = int.TryParse(Console.ReadLine(), out int Z);
            if (res2)
            {
                Console.Write($"Enter collection index :");
                bool res3 = int.TryParse(Console.ReadLine(), out int C);
                if (res3)
                {
                    Console.WriteLine($"\n7. Insert method that allows you to add an element to an arbitrary array position: {arr2.Insert(Z, C)}");
                    ShowThisCollection(arr2);
                }
            }
            else
            {
                Console.WriteLine("Excaption! Enter Int type!\n");
                Main();
            }
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
