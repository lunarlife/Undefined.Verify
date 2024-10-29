namespace Undefined.Verifying.Exceptions;

public class IsNotException : Exception
{
    public IsNotException(Type type, Type expected, string? message) : base(
        $"Object of type {type} was unexpected. Must be type {expected}. {message}")
    {
    }

    public IsNotException(string? message) : base(message)
    {
    }
}