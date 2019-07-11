using System;

namespace _2._2._TRIANGLE
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(5,5,5);
            if(triangle.DoesTriangleExist && triangle.EquilateralTriangle)
            {
                Console.WriteLine("Можно построить треугольник!\n");
                Console.WriteLine(triangle);
                Console.WriteLine("О, этот треугольник равносторонний!");
            }
            else if(triangle.DoesTriangleExist)
            {
                Console.WriteLine("Можно построить треугольник!\n");
                Console.WriteLine(triangle);
            }
            else
                Console.WriteLine("Построить треугольник невозможно! Это НЕ треугольник! Проверьте длины сторон треугольника!");

            Console.ReadLine();


        }
    }
}
