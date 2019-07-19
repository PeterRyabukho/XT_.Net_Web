using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8._GAME
{
    class Objects
    {
        public Point Coordinate { get; set; }

        public Objects(int x, int y)
        {
            Coordinate = new Point(x, y);
        }
    }
}
