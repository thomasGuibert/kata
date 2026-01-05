using System;
using System.Linq;

namespace Bowling
{
    internal class ScoreResolver
    {
        public ScoreResolver()
        {
        }

        internal int Resolve(Game game)
        {
            if (game.Results.Count != 5)
                throw new Exception($"Game contains {game.Results.Count} results but expected 5");
            
            var score = 0;
            for (var i = 0; i < game.Results.Count; i++)
            {
                score += Resolve(game, i);
            }
             return score;
        }

        private int Resolve(Game game, int i)
        {
            var score = 0;
            var frame = game.Results[i];

            if (frame.Score.Contains("/"))
            {
                score = 10 + int.Parse(game.Results[i + 1].Score[0]);
                return score;
            }
            if (frame.Score.Contains("x"))
            {
                score = 10 + Resolve(game , i+1);
                return score;
            }
            if (int.TryParse(frame.Score[0], out var incrFirst))
                score += incrFirst;
            if (int.TryParse(frame.Score[1], out var incrSecond))
                score += incrSecond;

            return score;
        }

    }
}