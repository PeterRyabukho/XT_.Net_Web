using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8._GAME
{
    class Bear: Creature
    {
        public Bear(int x, int y, int health, int atackPower) : base(x,y,health,atackPower)
        {

        }
        public Bear(int x, int y):this(x, y, health:100, atackPower:20)
        {

        }
    }
}
