using System;

namespace _0._1_Sequence
{
    class Program
    {
        private static string GetNumbers(int N)
        {
            string str = "";
            for (int i = 1; i <= N; i++)
            {
                str += i + " ";
            }
            return str;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите число N : ");
            bool res = int.TryParse(Console.ReadLine(), out int N);
            if (res && N > 0) 
            {
                Console.WriteLine(GetNumbers(N)); 
            }
            else Console.WriteLine("Задайте правильный числовой формат: целое положительное число, отличное от 0");

            Console.ReadKey();
        }
    }
}
