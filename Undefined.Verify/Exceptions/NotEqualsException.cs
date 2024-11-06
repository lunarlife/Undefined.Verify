namespace Undefined.Verifying.Exceptions;

public class NotEqualsException : Exception
{
    public NotEqualsException(object? first, object? second, string? message) : base($"{first} is not equal to {second}. {message}")
    {
    }
}