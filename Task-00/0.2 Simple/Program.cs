using System;

namespace _0._2_Simple
{
    class Program
    {
        private static bool SimpleNumber(int N)
        {
            for (int i = 2; i <= N / i; i++)
            {
                if ((N % i) == 0)
                    return false;
                
            }
            return true;
        }
        static void Main()
        {
            Console.Write("Хотите определить простое ли число? Введите число N : ");
            bool res = int.TryParse(Console.ReadLine(), out int N);
            if (res && N > 1)
            {
                if (SimpleNumber(N))
                    Console.WriteLine(N + " - Это простое число!");
                else
                    Console.WriteLine(N + " - Это НЕпростое число!");
            }
            else
            {
                Console.WriteLine("ОШИБКА! Задайте правильный числовой формат: целое положительное число, больше 1\n");
                Main();
            }

            Console.ReadKey();
        }
    }
}
