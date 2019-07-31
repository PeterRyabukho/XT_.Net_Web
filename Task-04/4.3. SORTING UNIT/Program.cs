using System;
using System.Threading;

namespace _4._3._SORTING_UNIT
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArraySorting sorting = new MyArraySorting();

            Console.Write("Array created: ");
            double[] arr = new double[] { 554, 34, 32, 772, 135, 543, 2, 4, 5 };
            sorting.ShowMeThisArray(arr);

            sorting.OnComplite += Sorting_OnComplite;

            Thread thread = new Thread(() =>
            {
                Console.WriteLine("Thread 2 start now!");
                sorting.SortMyArr(arr, (x, y) => x > y);
                Thread.Sleep(300);

                Console.Write("Creating sorted array 2:  ");
                foreach (var item in arr)
                {
                    Console.Write(item+" ");
                    Thread.Sleep(300);
                }
            });
            
            thread.Priority = ThreadPriority.Highest;
            thread.Start();
            
            Console.WriteLine("Thread 1 start now!");
            sorting.SortMyArr(arr, (x, y) => x > y);
            Console.Write("Creating sorted array 1:  ");
            sorting.ShowMeThisArray(arr);

            Console.ReadKey();
        }

        private static void Sorting_OnComplite(string obj)
        {
            Console.WriteLine("Sorting in thread is complite!");
        }

    }
}
