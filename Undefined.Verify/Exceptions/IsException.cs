namespace Undefined.Verifying.Exceptions;

public class IsException : Exception
{
    public IsException(Type notExpected, string? message) : base(
        $"Object of type {notExpected} was unexpected. {message}")
    {
    }

    public IsException(Type type, Type[] notExpected, string? message) : base(
        $"Object of type {type} was unexpected. Unexpected types: {string.Join(", ", notExpected.AsEnumerable())}. {message}")
    {
    }

    public IsException(string? message) : base(message)
    {
    }
}