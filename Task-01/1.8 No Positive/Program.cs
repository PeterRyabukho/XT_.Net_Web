using System;

namespace _1._8_No_Positive
{
    class Program
    {
        private static void getArr(int[,,] arr, Random random)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int z = 0; z < arr.GetLength(2); z++)
                    {
                        arr[i, j, z] = random.Next(-100, 100);
                    }
                }
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write("Массив №{0}: ", i);
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int z = 0; z < arr.GetLength(2); z++)
                    {
                        Console.Write(arr[i, j, z]);
                        Console.Write(", ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        private static void noPositive(int[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write("Массив №{0}: ", i);
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int z = 0; z < arr.GetLength(2); z++)
                    {
                        if (arr[i, j, z] < 0)
                            arr[i, j, z] = 0;
                        Console.Write(arr[i, j, z]);
                        Console.Write(", ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int[,,] arr = new int[3, 5, 5];
            Random random = new Random();

            getArr(arr, random);

            Console.WriteLine("----------------------------------------\n");

            noPositive(arr);

            Console.ReadLine();
        }
    }
}
