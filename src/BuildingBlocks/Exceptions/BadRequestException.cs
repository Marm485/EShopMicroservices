using System;

namespace BuildingBlocks.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException() : base("Bad request!")
    {

    }
    public BadRequestException(string message)
        : base(message)
    {

    }
    public BadRequestException(string name, object obj)
        : base($"Bad request: Entity \"{name}\" ({obj}).")
    {

    }
}
