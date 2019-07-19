using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8._GAME
{
    class Wolf: Creature
    {
        public Wolf(int x, int y, int health, int atackPower) : base(x, y, health, atackPower)
        {

        }
        public Wolf(int x, int y) : this(x, y, health: 70, atackPower: 50)
        {

        }
    }
}
