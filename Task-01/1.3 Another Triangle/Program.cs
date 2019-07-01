using System;

namespace _1._3_Another_Triangle
{
    class Program
    {
        private static void AnotherTriangle(int N)
        {
            for (int i = 1; i <= N; i++)
            {
                for (int j = i; j <= N; j++)
                {
                    Console.Write(" ");
                }
                for (int z = 1; z <= 2 * i - 1; z++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введите высоту треугольника : ");
            bool res = int.TryParse(Console.ReadLine(), out int N);
            if (res && N > 0)
            {
                AnotherTriangle(N);
            }
            else Console.WriteLine("Задайте правильный числовой формат: целое положительное число, отличное от 0!");

            Console.ReadKey();
        }
    }
}
