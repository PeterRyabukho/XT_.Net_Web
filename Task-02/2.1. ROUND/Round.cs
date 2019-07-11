using System;
using System.Collections.Generic;
using System.Text;

namespace _2._1._ROUND
{
    class Round
    {
        public int X { get; set; }
        public int Y { get; set; }
        private double r;

        public Round(int x, int y, double r)
        {
            X = x;
            Y = y;
            Radius = r;
        }

        public double Radius
        {
            get { return r; }
            set {
                if (value > 0)
                    r = value;
                else
                    throw new ArgumentException("Число должно быть положительное и отличное от 0!");
            }
        }

        public double LengthRound => 2 * Math.PI * Radius;
        public double GetArea => Math.PI * Radius * Radius;

        public override string ToString()
        {
            return $"Координаты х, y = {X}, {Y}\tРадиус: {Radius}\n\nДлина окружности: {LengthRound:.000}\tПлощадь круга: {GetArea:.000}";
        }
    }
}
