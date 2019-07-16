using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8._GAME
{
    class Mobs: Objects, IMovable
    {
        public int Health { get; set; }
        public int AtackPower { get; set; }
        public Mobs(int x, int y):base(x, y)
        {
              
        }

        public Mobs(int x, int y, int health, int atackPower):base(x,y)
        {
            this.Health = health;
            this.AtackPower = atackPower;
        }

        void IMovable.Move(Point point)
        {
            Coordinate = point;
        }
    }
}
