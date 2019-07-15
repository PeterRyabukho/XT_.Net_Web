using System;
using System.Collections.Generic;
using System.Text;

namespace _2._7._VECTOR_GRAPHICS_EDITOR
{
    class Circle: RoundShape
    {
        public new string Name { get; } = "Круг";

        public Circle(int x, int y, int radius):base(x,y,radius)
        {
            //this.X = x;
            //this.Y = y;
            this.Radius = radius;
        }

        public Circle():this(0,0,1)
        {

        }

        public double CircleArea => Math.PI * Radius * Radius;

        public override string Draw()
        {
            return Name + base.Draw();
        }

        public override string ToString()
        {
            return $"\nФигура: {Name}\nКоординаты центра фигуры: {CoordinatPoint}\nПлощадь: {CircleArea:.00}\nДлинна окружности: {OuterLength:.00}\n";
        }
    }
}
