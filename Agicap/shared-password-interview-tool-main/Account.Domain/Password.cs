using Account.Domain.UnitTests;
using System;

namespace Account.Domain;

public record Password(string Value)
{
    public bool IsValid(string passwordInput)
    {
        var lowercasePassword = passwordInput.ToLower();
        foreach (var c in lowercasePassword)
        {
            var characterCount = lowercasePassword.Count(c);
            if (characterCount >= 3) return false;
        }

        for (var index = 0; index < lowercasePassword.Length - 1; index++)
        {
            var currentCharacter = lowercasePassword[index];
            var nextCharacter = lowercasePassword[index + 1];
            if (currentCharacter == nextCharacter) return false;
        }

        return true;
    }

    public static void From(string passwordInput)
    {
        if (!IsValid(passwordInput)) throw new UnsecuredPasswordError("**Unsecured Value submitted.**");
    }
}