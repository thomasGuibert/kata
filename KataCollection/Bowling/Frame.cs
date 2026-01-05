using System.Collections.Generic;

namespace Bowling
{
    internal class Frame
    {
        public IList<string> Score => _throws;

        private readonly IList<string> _throws = new List<string>();

        private Frame()
        {
        }

        public static Frame AddFristThrow(string knockDownCount)
        {
            var instance = new Frame();
            instance.AddScore(knockDownCount);

            return instance;
        }

        public Frame AddSecondThrow(string knockDownCount)
        {
            AddScore(knockDownCount);
            return this;
        }

        private void AddScore(string knockDownCount)
        {
            _throws.Add(knockDownCount);
        }

    }
}