using BotInterface.Bot;
using BotInterface.Game;

namespace DynoRock
{
    public class DynoRockBot : IBot
    {
        private int dynamite_remaining = 100;
        public Move MakeMove(Gamestate gamestate)
        {
            if (dynamite_remaining > 0)
            {
                dynamite_remaining--;
                return Move.D;
            }
            return Move.R;
        }
    }
}
