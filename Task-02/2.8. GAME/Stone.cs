using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8._GAME
{
    class Stone: Objects, IDoNothing
    {
        public Stone(int x , int y):base(x,y)
        {

        }

        public string DoNothing()
        {
            return "Im just a stone...";
        }
    }
}
