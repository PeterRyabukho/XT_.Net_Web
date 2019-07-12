using System;
using System.Collections.Generic;
using System.Text;

namespace _2._6._RING
{
    class RoundShape
    {
        public int X { get; set; }
        public int Y { get; set; }
        private int radius;

        public int Radius
        {
            get { return radius; }
            set
            {
                if (value > 0)
                    radius = value;
                else
                    throw new ArgumentException("Ошибка! Радиус не может быть отрицателен или равен 0!");
            }
        }

        public RoundShape(int x, int y, int radius)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
        }
        public RoundShape()
        {
            X = 0;
            Y = 0;
            Radius = 1;
        }

        public double OuterLength => 2 * Math.PI * Radius;

        public override string ToString()
        {
            return $"\nСоздана ОКРУЖНОСТЬ с координатами [X,Y]-[{X},{Y}] и радиусом - {Radius}мм\nДлинна окружности: {OuterLength:.000}мм\n";
        }
    }
}
