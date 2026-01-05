using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumber
{

    public class RomanNumberConverter
    {
        private readonly IReadOnlyDictionary<int, string> _letters = new Dictionary<int, string>
        {
            { 1, "I"},
            { 4, "IV"},
            { 5, "V"},
            { 9, "IX"},
            { 10, "X" }
        };


        public string ConvertDigit(int number)
        {
            foreach(var symbolValue in _letters.Keys.OrderByDescending(k => k))
            {
                if(number >= symbolValue)
                    return _letters[symbolValue] + ConvertDigit(number - symbolValue);
            }

            return "";
        }
    }
}
