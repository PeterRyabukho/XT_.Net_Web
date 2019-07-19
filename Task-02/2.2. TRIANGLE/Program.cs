using System;

namespace _2._2._TRIANGLE
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = DrawRound();
            if (triangle.DoesTriangleExist && triangle.EquilateralTriangle)
            {
                Console.WriteLine("\nМожно построить треугольник!");
                Console.WriteLine(triangle);
                Console.WriteLine("О, этот треугольник равносторонний!");
            }
            else if (triangle.DoesTriangleExist)
            {
                Console.WriteLine("\nМожно построить треугольник!");
                Console.WriteLine(triangle);
            }
            else
            {
                Console.WriteLine("\nПостроить треугольник невозможно! Это НЕ треугольник! Проверьте длины сторон треугольника!\n");
                DrawRound();
            }

            Console.ReadLine();


        }
        public static void CreatTriangle()
        {
            //Triangle triangle = new Triangle();
        }
        public static Triangle DrawRound()
        {
            Triangle triangle;
            Console.Write("Введите сторону a: ");
            bool parse1 = double.TryParse(Console.ReadLine(), out double a);
            if (parse1 && a>0)
            {
                Console.Write("Введите сторону b: ");
                bool parse2 = double.TryParse(Console.ReadLine(), out double b);
                if (parse2 && b>0)
                {
                    Console.Write("Введите сторону c: ");
                    bool parse3 = double.TryParse(Console.ReadLine(), out double c);
                    if (parse3 && c>0)
                    {
                        return triangle = new Triangle(a, b, c);
                    }
                    else
                    {
                        Console.WriteLine("\nОшибка!!! Длина стороны должна быть положительным значимым числом(можно с плавующей запятой) и отличным от 0!\n");
                        DrawRound();
                    }
                }
                else
                {
                    Console.WriteLine("\nОшибка!!! Длина стороны должна быть положительным значимым числом(можно с плавующей запятой) и отличным от 0!\n");
                    DrawRound();
                }
            }
            else
            {
                Console.WriteLine("\nОшибка!!! Длина стороны должна быть положительным значимым числом(можно с плавующей запятой) и отличным от 0!\n");
                DrawRound();
            }
            return triangle = new Triangle();
        }
    }
}
