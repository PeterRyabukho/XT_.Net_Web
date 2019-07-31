using System;

namespace _4._2._CUSTOM_SORT_DEMO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Array of strings is created: ");
            string[] str = { "Magicians", "use", "this", "technique", "because", "every", "card", "is", "in", "a", "known", "Location", "after", "each", "shuffle", "and", "the", "order", "is", "a", "repeating", "pattern", "location" };
            ShowMeThisArray(str);

            SortMyArr(str, MyCompare);
            Console.WriteLine("\nArray after sorting: ");
            ShowMeThisArray(str);

            Console.ReadKey();
        }

        private static void ShowMeThisArray<T>(T[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        private static bool MyCompare(string str1, string str2)
        {
            if(str1.Length > str2.Length)
            {
                return true;
            }
            if (str1.Length==str2.Length)
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    if (str1[i] > str2[i])
                        return true;
                }
            }
            return false;
        }

        private static void SortMyArr<T>(T[] arr, Func<T, T, bool> comp)
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
        }
    }
}
