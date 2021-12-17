using BotInterface.Bot;
using BotInterface.Game;

namespace Paper
{
    public class PaperBot : IBot
    {
        public Move MakeMove(Gamestate gamestate)
        {
            return Move.P;
        }
    }
}
