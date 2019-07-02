using System;

namespace _0._3._Square
{
    class Program
    {
        private static void BuildSquare(int N)
        {
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    if (i == ((N+1)/2) & (j == ((N+1)/2)))
                    {
                        Console.Write(" ");
                        j++;
                    }
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        static void Main()
        {
            Console.Write("Укажите размер квадрата, введя длинну стороны N: ");
            bool res = int.TryParse(Console.ReadLine(), out int N);
            if (res && N > 0 && N % 2 != 0)
            {
                BuildSquare(N);
            }
            else
            {
                Console.WriteLine("ОШИБКА! Задайте правильный числовой формат: нечетное целое положительное число, больше двух\n");
                Main();
            }

            Console.ReadKey();
        }
    }
}
