using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordWrap
{
    public class Sentense
    {
        private const string Separator = " ";
        private readonly string _input;
        private int _rowSize;
        private IEnumerable<Token> tokens = new List<Token>();

        private Sentense(string input, int rowSize = 10)
        {
            _input = input;
            _rowSize = rowSize;
        }

        public static Sentense CreateSentense(string input)
        {
            var sentense = new Sentense(input);
            sentense.Tokenize();
            return sentense;
        }

        public Sentense WithRowSize(int rowSize)
        {
            _rowSize = rowSize;
            return this;
        }

        public override string ToString()
        {
            var sentenceBuilder = new StringBuilder();
            var rowBuilder = new StringBuilder();

            foreach (var token in tokens)
            {
                if (token.EndIndex + rowBuilder.Length > _rowSize)
                {
                    sentenceBuilder.Append(rowBuilder.ToString().Trim() + "\n");
                    rowBuilder = new StringBuilder();
                    rowBuilder.Append(token.Value);
                    continue;
                }
                rowBuilder.Append(token.Value);
                rowBuilder.Append(Separator);
            }
            sentenceBuilder.Append(rowBuilder.ToString());
            return sentenceBuilder.ToString().Trim();
        }

        private void Tokenize()
        {
            var words = _input.Split(Separator).ToList();
            var index = 0;
            tokens = words.Select(word =>
            {
                var token = new Token(word, index);
                index += word.Length;
                return token;
            });
        }
    }
}