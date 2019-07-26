﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _2._7._VECTOR_GRAPHICS_EDITOR
{
    class Line : Figure
    {
        public string Name { get; } = "Линия";

        public Point P1 { get; }
        public Point P2 { get; }

        public Line(Point startPoint, Point endPoint)
        {
            this.P1 = startPoint;
            this.P2 = endPoint;
        }

        public double LineLength()
        {
            double x = (P2.X - P1.X);
            double y = (P2.Y - P1.Y);
            return Math.Sqrt(Math.Pow(x, 2) + (Math.Pow(y, 2)));
        }

        public override string Draw()
        {
            return $"\nНа экране нарисованна - {Name}! С заданными параметрами, указанными выше!\n";
        }
        public override string ToString()
        {
            return $"\nФигура: {Name}\nКоординаты начальной точки: {P1}\tКоординаты конечной точки: {P2}\nДлинна полученной линии: {LineLength():.00мм}\n{Draw()}";
        }
    }
}