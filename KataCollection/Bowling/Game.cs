using System.Collections.Generic;

namespace Bowling
{
    internal class Game
    {
        private readonly IList<Frame> _frames = new List<Frame>();
        public IList<Frame> Results { get => _frames; }

        public Game()
        {
        }

        internal void AddFrame(Frame frame)
        {
            _frames.Add(frame);
        }
    }
    }