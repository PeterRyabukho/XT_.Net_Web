using System;

namespace _1._7_Array_Processing
{
    class Program
    {
        private static void getArr(int[] arr, Random r)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(0, 100);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0}, ", arr[i]);
            }
        }

        static void SortArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int z = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = z;
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0}, ", arr[i]);
            }
        }
        static int MaxArr(int[] arr)
        {
            int max = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;
        }
        static int MinArr(int[] arr)
        {
            int min = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }
        static void Main(string[] args)
        {
            int[] arr = new int[30];
            Random r = new Random();

            Console.Write("Исходный массив: [");
            getArr(arr, r);
            Console.Write("]\n");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Минимальное число в массиве: {0}; \nМаксимальное число в массиве: {1}; ", MinArr(arr), MaxArr(arr));

            Console.Write("Массив после сортировки по возрастанию значений: [");
            SortArr(arr);
            Console.Write("]");
            Console.ReadKey();
        }
    }
}
