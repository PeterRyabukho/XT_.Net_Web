using System;

namespace _1._4_X_Mas_Tree
{
    class Program
    {
        private static void Triangle(int N, int max)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < max - i - 1; j++)
                {
                    Console.Write(" ");
                }
                for (int z = 0; z < 2 * i + 1; z++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        private static void XmasTree(int N)
        {
            for (int i = 0; i < N; i++)
                Triangle(i + 1, N);
        }

        static void Main()
        {
            Console.Write("Введите число N треугольников в ёлочке: ");
            bool res = int.TryParse(Console.ReadLine(), out int N);
            if (res && N > 0)
            {
                XmasTree(N);
            }
            else
            {
                Console.WriteLine("ОШИБКА! Задайте правильный числовой формат: целое положительное число, отличное от 0!");
                Main();
            }

            Console.ReadKey();
        }
    }
}
