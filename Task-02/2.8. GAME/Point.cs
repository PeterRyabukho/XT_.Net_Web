﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8._GAME
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point():this(0,0)
        {}

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}

