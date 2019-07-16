using System;
using System.Collections.Generic;
using System.Text;

namespace _2._7._VECTOR_GRAPHICS_EDITOR
{
    class RoundShape: Figure
    {
        public string Name { get; } = "Окружность";

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

        public RoundShape(int x, int y, int radius):base(x,y)
        {
            this.Radius = radius;
        }
        public RoundShape():this(0,0,1)
        {

        }

        public double OuterLength => 2 * Math.PI * Radius;

        public new virtual string Draw()
        {
            return $"\nНа экране нарисованна - {Name}! С заданными параметрами, указанными выше!\n";
        }

        public override string ToString()
        {
            return $"Фигура: {Name}\nКоординаты центра фигуры [X,Y]: {CoordinatPoint}\nРадиус - {Radius}мм\nДлинна окружности: {OuterLength:.00}мм\n{Draw()}";
        }
    }
}
