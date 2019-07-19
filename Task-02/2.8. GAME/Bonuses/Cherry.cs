using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8._GAME
{
    class Cherry: Bonus
    {
        public Cherry(int x, int y) : base(x, y)
        {
            InfluenceBonus = 50;
        }
        public int Heal => 50;
    }
}
