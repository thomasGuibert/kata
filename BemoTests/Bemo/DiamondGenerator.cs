using System.Text;

namespace Bemo;

public class DiamondGenerator
{
    private const char ALetter = 'A';
    private const char BLetter = 'B';

    public static string For(char letter)
    {
        if (letter == ALetter) return ALetter.ToString();

        var emptySpaces = string.Concat(Enumerable.Repeat(' ', letter - ALetter));
        var diamondBuilder = new StringBuilder($"{emptySpaces}A");

        var spacesCount = 1;
        for (char currentLetter = BLetter; currentLetter <= letter; currentLetter++)
        {
            diamondBuilder.AppendLine();
            var row = LetterRow.For(currentLetter).BuildRow(letter, spacesCount); ;
            diamondBuilder.Append(row);
            spacesCount += 2;
        }
        spacesCount -= 2;

        var letterCopy = letter;
        for (var currentLetter = --letterCopy; currentLetter != ALetter; currentLetter--)
        {
            spacesCount -= 2;

            diamondBuilder.AppendLine();
            var row = LetterRow.For(currentLetter).BuildRow(letter, spacesCount); ;
            diamondBuilder.Append(row);
        }

        diamondBuilder.AppendLine();
        diamondBuilder.Append($"{emptySpaces}A");
        diamondBuilder.AppendLine();
        return diamondBuilder.ToString();
    }
}

public class LetterRow
{
    private const char EmptySpace = ' ';
    private readonly char _currentLetter;

    private LetterRow(char currentLetter)
    {
        _currentLetter = currentLetter;
    }

    public static LetterRow For(char currentLetter)
    {
        return new LetterRow(currentLetter);
    }

    public string BuildRow(char letter, int spacesCount)
    {
        var currentEmptySpaces = string.Concat(Enumerable.Repeat(EmptySpace, spacesCount));
        var beforeSpaces = string.Concat(Enumerable.Repeat(EmptySpace, letter - _currentLetter));
        return $"{beforeSpaces}{_currentLetter}{currentEmptySpaces}{_currentLetter}";
    }
}