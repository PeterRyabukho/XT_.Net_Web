using System;
using System.Collections.Generic;
using System.Text;

namespace _2._2._TRIANGLE
{
    class Triangle
    {
        private double a;
        private double b;
        private double c;

        public double A { get { return a; } set { if (value > 0) a = value; else throw new ArgumentException("Сторона треугольника должна быть положительной и больше 0 !"); } }
        public double B { get { return b; } set { if (value > 0) b = value; else throw new ArgumentException("Сторона треугольника должна быть положительной и больше 0 !"); } }
        public double C { get { return c; } set { if (value > 0) c = value; else throw new ArgumentException("Сторона треугольника должна быть положительной и больше 0 !"); } }

        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public Triangle()
        {

        }

        public bool DoesTriangleExist => (A <= B + C & B <= A + C & C <= A + B);

        public bool EquilateralTriangle => (A == B && B == C && C == A);

        public double Perimeter => A + B + C;
        private double Per => (Perimeter / 2);
        public double Area => Math.Sqrt((Per * (Per - A) * (Per - B) * (Per - C)));

        public override string ToString()
        {
            return $"\nСтороны треугольника равны а = {A}, b = {B}, c = {C}\n\nПериметр: {Perimeter}\tПлощадь: {Area:.000}\n";
        }
    }
}
