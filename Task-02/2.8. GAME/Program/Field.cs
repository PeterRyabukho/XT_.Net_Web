using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8._GAME
{
    class Field
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Field(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public static Field CreateField(int height, int width)
        {
            return new Field(height, width);
        }
    }
}
