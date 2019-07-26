using System;
using System.Collections.Generic;
using System.Collections;

namespace _4._1._CUSTOM_SORT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = new double[] { 88, 4, 99, 1, 7 };

            MySort<double> my = new MySort<double>();

            Sort(arr, (arr1) =>
                 {
                     for (int i = 0; i < arr.Length; i++)
                     {
                         for (int j = i + 1; j < arr.Length; j++)
                         {
                             if (arr[i] > arr[j])
                             {
                                 var move = arr[j];
                                 arr[j] = arr[i];
                                 arr[i] = move;
                             }
                         }
                     }
                     return arr1;
                 });    


            foreach (var item in arr)
            {
                Console.Write(item+" ");
            }

            Console.ReadKey();
        }

        public static T[] Sort<T>(T[] arr, Func<T[],T[]> x)
        {
            return x(arr);
        }

            //public static T[] Sort<T>(T[] arr, Func<T[], T, T> comp,T x)
            //{ 
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    for (int j = i+1; j < arr.Length; j++)
            //    {
            //        if(comp(arr[i])>0)
            //        {
            //            var move = arr[i];
            //            arr[i] = arr[j];
            //            arr[j] = move;

            //        }
            //    }
            //}
            //return arr;
            //}
    }
}
