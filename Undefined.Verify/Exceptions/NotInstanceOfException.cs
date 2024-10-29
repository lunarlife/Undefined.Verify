namespace Undefined.Verifying.Exceptions;

public class NotInstanceOfException : Exception
{
    public NotInstanceOfException(Type type, Type instanceOf, string? message) : base(
        $"Object of type {type} must be an instance of type {instanceOf}. {message}")
    {
    }

    public NotInstanceOfException(string? message) : base(message)
    {
    }
}