namespace WordWrap
{
    internal class Token
    {
        private readonly string _word;
        private readonly int _index;

        public Token(string word, int index)
        {
            _word = word;
            _index = index;
        }

        public int EndIndex
        {
            get
            {
                return _index + _word.Length;
            }
        }
        public string Value
        {
            get
            {
                return _word;
            }
        }
    }
}