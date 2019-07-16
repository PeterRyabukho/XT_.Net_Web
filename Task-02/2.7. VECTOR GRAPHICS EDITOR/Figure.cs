using System;
using System.Collections.Generic;
using System.Text;

namespace _2._7._VECTOR_GRAPHICS_EDITOR
{
    abstract class Figure
    {
        public Point CoordinatPoint { get; set; }
        public Figure():this(0,0)
        {

        }

        public Figure(int x, int y)
        {
            CoordinatPoint = new Point(x, y);
        }

        public virtual string Draw()
        {
            return "Рисуем фигуры";
        }
    }
}
