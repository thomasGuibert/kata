using System;

namespace Account.Domain.UnitTests;

public class UnsecuredPasswordError: Exception
{
    public UnsecuredPasswordError(string message) :base (message)
    {
        
    }
}