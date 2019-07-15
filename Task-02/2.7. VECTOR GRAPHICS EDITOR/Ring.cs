using System;
using System.Collections.Generic;
using System.Text;

namespace _2._7._VECTOR_GRAPHICS_EDITOR
{
    class Ring: RoundShape
    {
        public new string Name { get; } = "Кольцо";

        private int innerRadius;

        public int InnerRadius
        {
            get { return innerRadius; }
            set
            {
                if (value > 0 & value < Radius)
                    innerRadius = value;
                else
                    throw new ArgumentException("Ошибка! Внешний радиус должен быть БОЛЬШЕ внутреннего радиуса!");
            }
        }


        public Ring(int x, int y, int radius, int innerRadius) : base(x, y, radius)
        {
            this.InnerRadius = innerRadius;
        }

        public Ring()
        {
            InnerRadius = 2;
        }

        public double GetArea => Math.PI * (Radius * Radius - InnerRadius * InnerRadius);

        public double InnerLength => 2 * Math.PI * InnerRadius;

        public double SummLength => OuterLength + InnerLength;

        public override string Draw()
        {
            return Name + base.Draw();
        }

        public override string ToString()
        {
            return $"Фигура: {Name}\nКоординаты центра фигуры: [X,Y]-[{CoordinatPoint}]\nРадиус: {Radius}мм\nВнутренний радиус: {InnerRadius}\nСумма длинн внешней и внутренней окружностей кольца: {SummLength:.000}мм\nПлощадь кольца: {GetArea:.000}мм\n";
        }
    }
}
