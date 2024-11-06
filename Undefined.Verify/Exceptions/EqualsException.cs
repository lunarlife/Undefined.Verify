namespace Undefined.Verifying.Exceptions;

public class EqualsException : Exception
{
    public EqualsException(object? first, object? second, string? message) : base($"{first} is equal to {second}. {message}")
    {
    }
}