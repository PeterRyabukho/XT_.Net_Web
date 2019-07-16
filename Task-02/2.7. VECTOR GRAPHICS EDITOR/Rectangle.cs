using System;
using System.Collections.Generic;
using System.Text;

namespace _2._7._VECTOR_GRAPHICS_EDITOR
{
    class Rectangle: Figure
    {
        private int height;
        private int width;
        public string Name { get; } = "Прямоугольник";

        public int Width
        {
            get { return width; }
            set
            {
                if (value > 0)
                    width = value;
                else
                    throw new ArgumentException("Ошибка! Ширина прямоугольника не может быть отрицательной!");
            }
        }

        public int Height
        {
            get { return height; }
            set
            {
                if (value > 0)
                    height = value;
                else
                    throw new ArgumentException("Ошибка! Высота прямоугольника не может быть отрицательной!");
            }
        }

        public Rectangle(int height, int width, int x, int y):base(x,y)
        {
            this.Height = height;
            this.Width = width;
        }

        public double RectArea => height * width;

        public int RectPerimeter => 2 * (height + width);

        public override string Draw()
        {
            return $"\nНа экране нарисован - {Name}! С заданными параметрами, указанными выше!\n";
        }
        public override string ToString()
        {
            return $"\nФигура: {Name}\nКоординаты центра фигуры: {CoordinatPoint}\nВысота: {Width}мм\nШирина: {Height}мм\nПлощадь: {RectArea}мм\nПериметр: {RectPerimeter}мм\n{Draw()}";
        }
    }
}
