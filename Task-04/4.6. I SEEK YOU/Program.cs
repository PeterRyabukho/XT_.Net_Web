using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._6._I_SEEK_YOU
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Create new array: ");
            int[] arr = { -1, 4, 44, 7, -3, -77, 5, -876, 435, 43, -38, -2, 211 };
            ShowMeThisArray(arr);

            Console.Write("\n1. Simple method serching positive: ");
            var simpleSerch = SimpleFindPositive(arr);
            ShowMeThisArray(simpleSerch);

            Console.Write("2. Method, to which the search condition is passed through the delegate instance: ");
            Predicate<int> predicate = new Predicate<int>(GetPositiveIndex);
            var delegSerch = DelegFindPositive(arr, predicate);
            ShowMeThisArray(delegSerch);

            Console.Write("3. Method, to which the search condition is passed through the delegate as an anonymous method: ");
            var anonymSerch = DelegFindPositive(arr,
                delegate (int i)
                {
                    return i > 0;
                });
            ShowMeThisArray(anonymSerch);

            Console.Write("4. Method, to which the search condition is passed through the delegate in the form of lambda expression: ");
            var lambdaSerch = DelegFindPositive(arr, (i) => i > 0);
            ShowMeThisArray(lambdaSerch);

            Console.Write("4. Method, to which the search condition is passed through LINQ: ");
            var linqSerch = LinqFindPositive(arr);
            ShowMeThisArray(linqSerch);

            Console.ReadLine();
        }

        private static void ShowMeThisArray<T>(T[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        private static bool GetPositiveIndex(int i) => i > 0;

        private static int[] SimpleFindPositive(int[] arr)
        {
            List<int> ts = new List<int>();

            foreach (var item in arr)
            {
                if (item > 0)
                {
                    ts.Add(item);
                }
            }

            return ts.ToArray();
        }

        private static T[] DelegFindPositive<T>(T[] arr, Predicate<T> find)
        {
            List<T> ts = new List<T>();

            foreach (var item in arr)
            {
                if(find.Invoke(item))
                {
                    ts.Add(item);
                }
            }

            return ts.ToArray();
        }

        private static int[] LinqFindPositive(int[] arr)
        {
            arr = (from item in arr
                   where item > 0
                   select item).ToArray();

            return arr;
        }
    }
}
