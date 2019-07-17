using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8._GAME
{
    class Bonus: Objects
    {
        public Bonus(int x, int y):base(x,y)
        {

        }
        public int InfluenceBonus { get; set; } = 0;
    }
}
