using System;

namespace _1._1_Rectangle
{
    class Program
    {
        private static double Area(double a, double b)
        {
            return a * b;
        }

        private static void getNumbA()
        {
            Console.Write("Введите длинну прямоугольника: ");
            bool resA = double.TryParse(Console.ReadLine(), out double a);

            if (resA && a > 0)
            {
                getNumbB(a);
            }
            else
            {
                Console.WriteLine("ОШИБКА! Число должно быть положительное и отличное от нуля!\n");
                getNumbA();
            }
        }

        private static void getNumbB(double a)
        {
            Console.Write("Введите высоту прямоугольника: ");
            bool resB = double.TryParse(Console.ReadLine(), out double b);

            if (resB && b > 0)
            {
                Console.WriteLine("Площадь прямоугольника: " + Area(a, b));
            }
            else
            {
                Console.WriteLine("ОШИБКА! Число должно быть положительное и отличное от нуля!\n");
                getNumbB(a);
            }
        }

        static void Main(string[] args)
        {
            getNumbA();

            Console.ReadKey();
        }

    }
}
