using System;
using System.Collections.Generic;
using System.Collections;

namespace _4._1._CUSTOM_SORT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Array №1 created: ");
            double[] arr = new double[] { 88, 4.5, 99.9, 1, 7.1 };
            ShowMeThisArray(arr);

            Console.Write("Array №1 after sorting: ");
            SortMyArr(arr, (x, y) => x > y);
            ShowMeThisArray(arr);

            Console.Write("\nArray №2 created: ");
            double[] arrForTraining = new double[] { 33.7, 3, 72, 4.3, 77.3, 435, 6.1, 0.2 };
            ShowMeThisArray(arrForTraining);

            Console.Write("Array №2 after sorting: ");
            
            Sort(arrForTraining, (arr1) =>
            {
                for (int i = 0; i < arrForTraining.Length; i++)
                {
                    for (int j = i + 1; j < arrForTraining.Length; j++)
                    {
                        if (arrForTraining[i] > arrForTraining[j])
                        {
                            var move = arrForTraining[j];
                            arrForTraining[j] = arrForTraining[i];
                            arrForTraining[i] = move;
                        }
                    }
                }
                return arr1;
            });
            ShowMeThisArray(arrForTraining);

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

        /// <summary>
        /// Дополнительный метод Sort для тренировки с анонимными методами
        /// </summary>
        /// <param name="arr">ввод массива для сортировки</param>
        /// <param name="x">делегат для создания анонимного метода с массивом на входе и алгоритмом сортировки пузырьком</param>
        /// <returns></returns>
        private static T[] Sort<T>(T[] arr, Func<T[],T[]> x)
        {
            return x(arr);
        }

        private static void SortMyArr<T>(T[] arr, Func<T, T, bool> comp)
        {
            if (comp == null)
            {
                throw new ArgumentNullException("Array is empty!");
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    if(comp(arr[i],arr[j]))
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
