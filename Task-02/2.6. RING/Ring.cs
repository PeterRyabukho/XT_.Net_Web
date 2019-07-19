using System;
using System.Collections.Generic;
using System.Text;

namespace _2._6._RING
{
    class Ring: RoundShape
    {
        private double innerRadius;

        public double InnerRadius
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

        public Ring(int x, int y, double radius, double innerRadius):base(x,y,radius)
        {
            this.InnerRadius = innerRadius;
        }

        public Ring():this(0,0,2,1)
        {

        }

        public double GetArea => Math.PI * (Radius * Radius - InnerRadius * InnerRadius);

        public double InnerLength => 2 * Math.PI * InnerRadius;

        public double SummLength => OuterLength + InnerLength;

        public override string ToString()
        {
            return $"\nСоздано КОЛЬЦО с координатами [X,Y]-[{X},{Y}], \nВнешним радиусом - {Radius}мм и внутренним радиусом - {InnerRadius}мм\nСумма длинн внешней и внутренней окружностей кольца: {SummLength:.000}мм\nПлощадь кольца: {GetArea:.000}мм\n";
        }
    }
}
