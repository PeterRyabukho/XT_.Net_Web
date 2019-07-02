using System;

namespace _1._2_Triangle
{
    class Program
    {
        private static void BuildTriangle(int N)
        {
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        private static bool check()
        {
            Console.Write("Введите высоту треугольника : ");

            bool res = int.TryParse(Console.ReadLine(), out int N);
            if (res && N > 0)
            {
                BuildTriangle(N);
                return true;
            }
            else
            {
                Console.WriteLine("ОШИБКА! Задайте правильный числовой формат: целое положительное число, отличное от 0!\n");
                return false;
            }
        }
        static void Main()
        {
            while (check() == false)
                check();

            Console.ReadKey();
        }
    }
}
