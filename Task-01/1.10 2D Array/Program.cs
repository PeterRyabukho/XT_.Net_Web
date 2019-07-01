using System;

namespace _1._10_2D_Array
{
    class Program
    {
        private static void getArr(int[,] arr, Random random)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = random.Next(1, 11);
                }
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("[{0},{1}]-", i, j);
                    Console.Write(arr[i, j]);
                    Console.Write(",\t");
                }
                Console.WriteLine();
            }
        }

        private static int getSum(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                        sum += arr[i, j];
                }
            }
            return sum;
        }

        static void Main(string[] args)
        {
            int[,] arr = new int[4, 4];
            Random random = new Random();

            getArr(arr, random);

            Console.WriteLine("Сумма элементов массива на четных позициях равна = {0}", getSum(arr));

            Console.ReadKey();
        }
    }
}
