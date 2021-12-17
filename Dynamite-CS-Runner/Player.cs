using BotInterface.Bot;
using BotInterface.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamite_CS_Runner
{
    class Player
    {
        public IBot Bot;
        public Gamestate Gamestate;
        public int Score;
        public string Name;
        public int DynamiteRemaining;
    }
}
