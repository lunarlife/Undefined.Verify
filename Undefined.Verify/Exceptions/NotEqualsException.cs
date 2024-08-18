namespace Undefined.Verifying.Exceptions;

public class NotEqualsException : Exception
{
    public NotEqualsException(string? message) : base($"Objects are not equals. {message}")
    {
    }
}