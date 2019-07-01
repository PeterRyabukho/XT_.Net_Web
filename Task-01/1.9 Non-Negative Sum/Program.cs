using System;

namespace _1._9_Non_Negative_Sum
{
    class Program
    {
        private static void getArr(int[] arr, Random random)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-100, 100);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0}, ", arr[i]);
            }
        }

        private static int nonNegSum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                    sum += arr[i];
            }

            return sum;
        }

        static void Main(string[] args)
        {
            int[] arr = new int[30];
            Random random = new Random();

            Console.Write("Исходный массив: [");
            getArr(arr, random);
            Console.Write("]\n");

            int sum = nonNegSum(arr);
            Console.WriteLine("\nСумма положительных элементов в массиве = {0}", sum);

            Console.ReadKey();
        }
    }
}
