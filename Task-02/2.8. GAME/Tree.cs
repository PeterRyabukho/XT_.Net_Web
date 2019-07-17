using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8._GAME
{
    class Tree: Objects, IDoNothing
    {
        public Tree(int x, int y) : base(x, y)
        {

        }

        string IDoNothing.DoNothing()
        {
            return "Im just a tree...";
        }
    }
}
