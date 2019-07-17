using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8._GAME
{
    class Spider: Creature
    {
        public Spider(int x, int y, int health, int atackPower) : base(x, y, health, atackPower)
        {

        }
        public Spider(int x, int y) : this(x, y, health: 40, atackPower: 40)
        {

        }
    }
}
