using BotInterface.Game;
using System;

namespace Dynamite_CS_Runner
{
    class GameRunner
    {

        private void AddRoundToGameState(Player player, Move move, Move opponentMove)
        {
            var rounds = player.Gamestate.GetRounds();
            var newRounds = new Round[rounds.Length + 1];
            for (var i = 0; i < rounds.Length; i++)
            {
                newRounds[i] = rounds[i];
            }
            var newRound = new Round();
            newRound.SetP1(move);
            newRound.SetP2(opponentMove);

            newRounds[rounds.Length] = newRound;
            if (move == Move.D)
            {
                player.DynamiteRemaining -= 1;
            }
            player.Gamestate.SetRounds(newRounds);
        }

        private RoundResult GetRoundResult(Move p1Move, Move p2Move)
        {
            if (p1Move == p2Move)
            {
                return RoundResult.Draw;
            }
            // Check for a winner
            if (
                (p1Move == Move.D && p2Move != Move.W) ||
                (p1Move == Move.W && p2Move == Move.D) ||
                (p1Move == Move.R && p2Move == Move.S) ||
                (p1Move == Move.S && p2Move == Move.P) ||
                (p1Move == Move.P && p2Move == Move.R) ||
                (p1Move != Move.D && p2Move == Move.W)
            )
            {
                return RoundResult.P1Win;
            }
            else
            {
                return RoundResult.P2Win;
            }
        }

        private string GetGameResult(Player p1, Player p2, int round_number)
        {
            if (p1.DynamiteRemaining < 0 && p2.DynamiteRemaining < 0)
            {
                return "DRAW: Both players used too much Dynamite";
            }
            if (p1.DynamiteRemaining < 0)
            {
                return $"{p2.Name} wins: {p1.Name} used too much Dynamite";
            }
            if (p2.DynamiteRemaining < 0)
            {
                return $"{p1.Name} wins: {p2.Name} used too much Dynamite";
            }
            if (round_number >= Program.MAX_ROUNDS)
            {
                return "DRAW: Max rounds exceeded";
            }
            if (p1.Score >= Program.TARGET_SCORE && p1.Score > p2.Score)
            {
                return $"{p1.Name} wins: ({p1.Score} - {p2.Score})";
            }
            if (p2.Score >= Program.TARGET_SCORE && p2.Score > p1.Score)
            {
                return $"{p2.Name} wins: ({p1.Score} - {p2.Score})";
            }
            return null;
        }

        public void GameLoop(Player p1, Player p2)
        {
            int round_number = 1;
            int draw_count = 0;
            string gameResult = null;
            while (gameResult == null)
            {
                var p1Move = p1.Bot.MakeMove(p1.Gamestate);
                var p2Move = p2.Bot.MakeMove(p2.Gamestate);

                AddRoundToGameState(p1, p1Move, p2Move);
                AddRoundToGameState(p2, p2Move, p1Move);

                var roundResult = GetRoundResult(p1Move, p2Move);
                Console.WriteLine($"Round {round_number:0000} P1: {p1Move} P2: {p2Move} ({roundResult})");
                if (roundResult == RoundResult.P1Win)
                {
                    p1.Score += 1 + draw_count;
                    draw_count = 0;
                }
                else if (roundResult == RoundResult.P2Win)
                {
                    p2.Score += 1 + draw_count;
                    draw_count = 0;
                }
                else
                {
                    draw_count++;
                }
                gameResult = GetGameResult(p1, p2, round_number);
                round_number++;
            }
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("");
            Console.WriteLine(gameResult);
        }
    }

    internal enum RoundResult
    {
        P1Win,
        P2Win,
        Draw,
    }
}
