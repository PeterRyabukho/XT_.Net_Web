using System;
using System.Collections.Generic;
using System.Text;

namespace _2._8._GAME
{
    sealed class BattleConfig
    {
        public int WinChanse { get; set; }
        public int AtackPowerChange { get; set; }

        public BattleResults WinResult { get; set; }
        public BattleResults LooseResult { get; set; }

    }
}
