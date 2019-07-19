using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8._GAME
{
    class GameConfig
    {
        public BattleConfig Battle { get; set; }
        public PlayerConfig player { get; set; }

        public GameConfig()
        {
            Battle = new BattleConfig();
            player = new PlayerConfig();
        }
    }
}
