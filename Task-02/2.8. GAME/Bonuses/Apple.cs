using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8._GAME
{
    class Apple: Bonus
    {
        public Apple(int x, int y):base(x,y)
        {
            InfluenceBonus = 20;
        }
    }
}
