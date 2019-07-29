using System;

namespace _4._4._NUMBER_ARRAY_SUM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Int array created: ");
            int[] arr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ShowMeThisArray(arr1);

            Console.WriteLine($"Sum of all int array elements is: {GetSumm((x,y)=>x+y,arr1)}");

            Console.Write("\nDouble array created: ");
            double[] arr2 = { 1.6, 2.3, 3.8, 4.2, 5.9, 6.2, 7.1, 8.4, 9.1 };
            ShowMeThisArray(arr2);

            Console.WriteLine($"Sum of all double array elements is: {GetSumm((x, y) => x + y, arr2)}");

            Console.Write("\nString array created: ");
            string[] arr3 = { "hi", "my", "name", "is", "Jon"};
            ShowMeThisArray(arr3);

            Console.WriteLine($"Sum of all double array elements is: {GetSumm((x, y) => x + y, arr3)}");

            Console.ReadKey();
        }

        public static T GetSumm<T>(Func<T, T, T> summFunc, T[] arr)
        {
            T multi = default;

            for (int i = 0; i < arr.Length; i++)
            {
                multi = summFunc(multi, arr[i]);
            }

            return multi;
        }
        private static void ShowMeThisArray<T>(T[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
