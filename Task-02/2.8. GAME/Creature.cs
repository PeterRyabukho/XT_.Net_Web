using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8._GAME
{
    abstract class Creature : Objects, IMovable
    {
        public int Health { get; set; }
        public int AtackPower { get; set; }
        public Creature(int x, int y):base(x, y)
        {
              
        }

        public Creature(int x, int y, int health, int atackPower):base(x,y)
        {
            this.Health = health;
            this.AtackPower = atackPower;
        }

        public virtual void Move(int x, int y)
        {
            Coordinate = new Point(x, y);
        }
    }
}
