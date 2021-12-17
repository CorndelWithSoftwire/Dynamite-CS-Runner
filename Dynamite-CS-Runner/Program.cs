using BotInterface.Bot;
using BotInterface.Game;
using System.IO;

namespace Dynamite_CS_Runner
{
    class Program
    {
        public const int TARGET_SCORE = 1000;
        public const int MAX_ROUNDS = 2500;
        public const int STARTING_DYNAMITE = 100;
        static void Main(string[] args)
        {
            var bot1 = new DynoRock.DynoRockBot();
            var bot2 = new Paper.PaperBot();
            // Can load a bot from a DLL instead e.g.
            // var bot1 = LoadBotFromDLLFile("C:\\path\\to\\DynamiteBot.dll");

            var player1 = new Player
            {
                Bot = bot1,
                Gamestate = new Gamestate(),
                Name = $"Player 1 ({bot1.GetType().Name})",
                Score = 0,
                DynamiteRemaining = STARTING_DYNAMITE,
            };
            var player2 = new Player
            {
                Bot = bot2,
                Gamestate = new Gamestate(),
                Name = $"Player 2 ({bot2.GetType().Name})",
                Score = 0,
                DynamiteRemaining = STARTING_DYNAMITE,
            };
            player1.Gamestate.SetRounds(new Round[0]);
            player2.Gamestate.SetRounds(new Round[0]);

            new GameRunner().GameLoop(player1, player2);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members")]
        private static IBot LoadBotFromDLLFile(string path)
        {
            var botBytes = File.ReadAllBytes(path);
            return BotLoader.InstantiateBot(botBytes);
        }
    }
}
